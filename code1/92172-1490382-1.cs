    Public Class ScreenRecorder
    Private Shared tempDir As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\snapshot\"
    Private Shared snap As New System.Threading.Thread(AddressOf Snapshot)
    Private Shared _Bounds As System.Drawing.Rectangle = System.Windows.Forms.Screen.PrimaryScreen.Bounds
    Public Shared Property Bounds() As System.Drawing.Rectangle
        Get
            Return _Bounds
        End Get
        Set(ByVal value As System.Drawing.Rectangle)
            _Bounds = value
        End Set
    End Property
    Private Shared Sub Snapshot()
        If Not My.Computer.FileSystem.DirectoryExists(tempDir) Then _
            My.Computer.FileSystem.CreateDirectory(tempDir)
        Dim Co As Integer = 0
        Do
            Co += 1
            System.Threading.Thread.Sleep(50)
            Dim X As New System.Drawing.Bitmap(_Bounds.Width, _Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            Using G = System.Drawing.Graphics.FromImage(X)
                G.CopyFromScreen(_Bounds.Location, New System.Drawing.Point(), _Bounds.Size)
                Dim CurBounds As New System.Drawing.Rectangle(System.Windows.Forms.Cursor.Position - Bounds.Location, System.Windows.Forms.Cursor.Current.Size)
                Forms.Cursors.Default.Draw(G, CurBounds)
            End Using
            Dim FS As New IO.FileStream(tempDir & FormatString(Co.ToString, 5, "0"c) & ".png", IO.FileMode.OpenOrCreate)
            X.Save(FS, System.Drawing.Imaging.ImageFormat.Png)
            X.Dispose()
            FS.Close()
        Loop
    End Sub
    Public Shared Sub ClearRecording()
        If My.Computer.FileSystem.DirectoryExists(tempDir) Then _
        My.Computer.FileSystem.DeleteDirectory(tempDir, FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.CreateDirectory(tempDir)
    End Sub
    Public Shared Sub Save(ByVal Output As String)
        Dim G As New Windows.Media.Imaging.GifBitmapEncoder
        Dim X As New List(Of IO.FileStream)
        For Each Fi As String In My.Computer.FileSystem.GetFiles(tempDir, FileIO.SearchOption.SearchTopLevelOnly, "*.png")
            Dim TempStream As New IO.FileStream(Fi, IO.FileMode.Open)
            Dim Frame = Imaging.BitmapFrame.Create(TempStream)
            X.Add(TempStream)
            G.Frames.Add(Frame)
        Next
        Dim FS As New IO.FileStream(Output, IO.FileMode.OpenOrCreate)
        G.Save(FS)
        FS.Close()
        For Each St As IO.FileStream In X
            St.Close()
        Next
    End Sub
    Public Shared Sub Start()
        snap = New System.Threading.Thread(AddressOf Snapshot)
        snap.Start()
    End Sub
    Public Shared Sub [Stop]()
        snap.Abort()
    End Sub
    Private Shared Function FormatString(ByVal S As String, ByVal places As Integer, ByVal character As Char) As String
        If S.Length >= places Then Return S
        For X As Integer = S.Length To places
            S = character & S
        Next
        Return S
    End Function
    End Class
