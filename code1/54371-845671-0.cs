    ''' <summary>
    ''' Encrypts a memory string (i.e. variable).
    ''' </summary>
    ''' <param name="data">String to be encrypted.</param>
    ''' <param name="key">Encryption key.</param>
    ''' <param name="iv">Encryption initialization vector.</param>
    ''' <returns>Encrypted string.</returns>
    Public Shared Function Encrypt(ByVal data As String, ByVal key As String, ByVal iv As String) As String
        Dim bdata As Byte() = Encoding.ASCII.GetBytes(data)
        Dim bkey As Byte() = HexToBytes(key)
        Dim biv As Byte() = HexToBytes(iv)
    
        Dim stream As MemoryStream = New MemoryStream
        Dim encStream As CryptoStream = New CryptoStream(stream, des3.CreateEncryptor(bkey, biv), CryptoStreamMode.Write)
    
        encStream.Write(bdata, 0, bdata.Length)
        encStream.FlushFinalBlock()
        encStream.Close()
    
        Return BytesToHex(stream.ToArray())
    End Function
    
    ''' <summary>
    ''' Decrypts a memory string (i.e. variable).
    ''' </summary>
    ''' <param name="data">String to be decrypted.</param>
    ''' <param name="key">Original encryption key.</param>
    ''' <param name="iv">Original initialization vector.</param>
    ''' <returns>Decrypted string.</returns>
    Public Shared Function Decrypt(ByVal data As String, ByVal key As String, ByVal iv As String) As String
        Dim bdata As Byte() = HexToBytes(data)
        Dim bkey As Byte() = HexToBytes(key)
        Dim biv As Byte() = HexToBytes(iv)
    
        Dim stream As MemoryStream = New MemoryStream
        Dim encStream As CryptoStream = New CryptoStream(stream, des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write)
    
        encStream.Write(bdata, 0, bdata.Length)
        encStream.FlushFinalBlock()
        encStream.Close()
    
        Return Encoding.ASCII.GetString(stream.ToArray())
    End Function
