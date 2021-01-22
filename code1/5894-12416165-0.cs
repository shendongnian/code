    ' Header chunk
    ' Type   Byte Offset  Description
    ' Dword       0       Always ASCII "RIFF"
    ' Dword       4       Number of bytes in the file after this value (= File Size - 8)
    ' Dword       8       Always ASCII "WAVE"
    ' Format Chunk
    ' Type   Byte Offset  Description
    ' Dword       12      Always ASCII "fmt "
    ' Dword       16      Number of bytes in this chunk after this value
    ' Word        20      Data format PCM = 1 (i.e. Linear quantization)
    ' Word        22      Channels Mono = 1, Stereo = 2
    ' Dword       24      Sample Rate per second e.g. 8000, 44100
    ' Dword       28      Byte Rate per second (= Sample Rate * Channels * (Bits Per Sample / 8))
    ' Word        32      Block Align (= Channels * (Bits Per Sample / 8))
    ' Word        34      Bits Per Sample e.g. 8, 16
    ' Data Chunk
    ' Type   Byte Offset  Description
    ' Dword       36      Always ASCII "data"
    ' Dword       40      The number of bytes of sound data (Samples * Channels * (Bits Per Sample / 8))
    ' Buffer      44      The sound data
    Dim HeaderData(43) As Byte
    Private AudioFileReference As String
    Public Sub New(ByVal AudioFileReference As String)
        Try
            Me.HeaderData = Read(AudioFileReference, 0, Me.HeaderData.Length)
        Catch Exception As Exception
            Throw
        End Try
        'Validate file format
        Dim Encoder As New UTF8Encoding()
        If "RIFF" <> Encoder.GetString(BlockCopy(Me.HeaderData, 0, 4)) Or _
           "WAVE" <> Encoder.GetString(BlockCopy(Me.HeaderData, 8, 4)) Or _
           "fmt " <> Encoder.GetString(BlockCopy(Me.HeaderData, 12, 4)) Or _
           "data" <> Encoder.GetString(BlockCopy(Me.HeaderData, 36, 4)) Or _
           16 <> ToUInt32(BlockCopy(Me.HeaderData, 16, 4), 0) Or _
           1 <> ToUInt16(BlockCopy(Me.HeaderData, 20, 2), 0) _
        Then
            Throw New InvalidDataException("Invalid PCM WAV file")
        End If
        Me.AudioFileReference = AudioFileReference
    End Sub
    ReadOnly Property Channels() As Integer
        Get
            Return ToUInt16(BlockCopy(Me.HeaderData, 22, 2), 0) 'mono = 1, stereo = 2
        End Get
    End Property
    ReadOnly Property SampleRate() As Integer
        Get
            Return ToUInt32(BlockCopy(Me.HeaderData, 24, 4), 0) 'per second
        End Get
    End Property
    ReadOnly Property ByteRate() As Integer
        Get
            Return ToUInt32(BlockCopy(Me.HeaderData, 28, 4), 0) 'sample rate * channels * (bits per channel / 8)
        End Get
    End Property
    ReadOnly Property BlockAlign() As Integer
        Get
            Return ToUInt16(BlockCopy(Me.HeaderData, 32, 2), 0) 'channels * (bits per sample / 8)
        End Get
    End Property
    ReadOnly Property BitsPerSample() As Integer
        Get
            Return ToUInt16(BlockCopy(Me.HeaderData, 34, 2), 0)
        End Get
    End Property
    ReadOnly Property Duration() As Integer
        Get
            Dim Size As Double = ToUInt32(BlockCopy(Me.HeaderData, 40, 4), 0)
            Dim ByteRate As Double = ToUInt32(BlockCopy(Me.HeaderData, 28, 4), 0)
            Return Ceiling(Size / ByteRate)
        End Get
    End Property
    Public Sub Play()
        Try
            My.Computer.Audio.Play(Me.AudioFileReference, AudioPlayMode.Background)
        Catch Exception As Exception
            Throw
        End Try
    End Sub
    Public Sub Play(playMode As AudioPlayMode)
        Try
            My.Computer.Audio.Play(Me.AudioFileReference, playMode)
        Catch Exception As Exception
            Throw
        End Try
    End Sub
    Private Function Read(AudioFileReference As String, ByVal Offset As Long, ByVal Bytes As Long) As Byte()
        Dim inputFile As System.IO.FileStream
        Try
            inputFile = IO.File.Open(AudioFileReference, IO.FileMode.Open)
        Catch Exception As FileNotFoundException
            Throw New FileNotFoundException("PCM WAV file not found")
        Catch Exception As Exception
            Throw
        End Try
        Dim BytesRead As Long
        Dim Buffer(Bytes - 1) As Byte
        Try
            BytesRead = inputFile.Read(Buffer, Offset, Bytes)
        Catch Exception As Exception
            Throw
        Finally
            Try
                inputFile.Close()
            Catch Exception As Exception
                'Eat the second exception so as to not mask the previous exception
            End Try
        End Try
        If BytesRead < Bytes Then
            Throw New InvalidDataException("PCM WAV file read failed")
        End If
        Return Buffer
    End Function
    Private Function BlockCopy(ByRef Source As Byte(), ByVal Offset As Long, ByVal Bytes As Long) As Byte()
        Dim Destination(Bytes - 1) As Byte
        Try
            Buffer.BlockCopy(Source, Offset, Destination, 0, Bytes)
        Catch Exception As Exception
            Throw
        End Try
        Return Destination
    End Function
