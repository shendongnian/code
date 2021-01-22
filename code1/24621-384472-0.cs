    Namespace Crypto
        
    	Public Class RSACry
    
            Shared Sub New()
            End Sub
    		
    		Public Enum Algorithms
                DES
                TDES
                RC2
                RDAEL
            End Enum
    
            Public Shared Function Encrypt(ByVal xmlkeystring As String, ByVal typo As Algorithms, ByVal datatoencrypt As String) As String
                Dim rsaer As RSA = Crypto.RSACry.ReadKeyString(xmlkeystring)
                Dim result() As Byte = Crypto.RSACry.EncryptIt(rsaer, typo, datatoencrypt)
                Return System.Convert.ToBase64String(result)
            End Function
    		
            Public Shared Function Decrypt(ByVal xmlkeystring As String, ByVal typo As Algorithms, ByVal datatodecrypt As String) As String
                Dim rsaer As RSA = Crypto.RSACry.ReadKeyString(xmlkeystring)
                Dim result() As Byte = Crypto.RSACry.DecryptIt(rsaer, typo, datatodecrypt)
                Return System.Text.Encoding.UTF8.GetString(result)
            End Function
    
    	    Friend Shared Function EncryptIt(ByRef rsaer As RSA, ByVal typo As Algorithms, ByVal datatoencrypt As String) As Byte()
                Dim result() As Byte = Nothing
    
                Try
                    Dim plainbytes() As Byte = System.Text.Encoding.UTF8.GetBytes(datatoencrypt)
                    Dim sa As SymmetricAlgorithm = SymmetricAlgorithm.Create(Crypto.RSACry.GetAlgorithmName(typo))
                    Dim ct As ICryptoTransform = sa.CreateEncryptor()
                    Dim encrypt() As Byte = ct.TransformFinalBlock(plainbytes, 0, plainbytes.Length)
                    Dim fmt As RSAPKCS1KeyExchangeFormatter = New RSAPKCS1KeyExchangeFormatter(rsaer)
                    Dim keyex() As Byte = fmt.CreateKeyExchange(sa.Key)
    
                    --return the key exchange, the IV (public) and encrypted data 
                    result = New Byte(keyex.Length + sa.IV.Length + encrypt.Length) {}
                    Buffer.BlockCopy(keyex, 0, result, 0, keyex.Length)
                    Buffer.BlockCopy(sa.IV, 0, result, keyex.Length, sa.IV.Length)
                    Buffer.BlockCopy(encrypt, 0, result, keyex.Length + sa.IV.Length, encrypt.Length)
    
                Catch ex As Exception
                    Throw New CryptographicException("Unable to crypt: " + ex.Message)
                End Try
    
                Return result
            End Function
    
            Friend Shared Function DecryptIt(ByRef rsaer As RSA, ByVal typo As Algorithms, ByVal datatodecrypt As String) As Byte()
                Dim result() As Byte = Nothing
    
                Try
                    Dim encrbytes() As Byte = System.Convert.FromBase64String(datatodecrypt)
                    Dim sa As SymmetricAlgorithm = SymmetricAlgorithm.Create(Crypto.RSACry.GetAlgorithmName(typo))
                    Dim keyex() As Byte = New Byte((rsaer.KeySize >> 3) - 1) {}
                    Buffer.BlockCopy(encrbytes, 0, keyex, 0, keyex.Length)
    
                    Dim def As RSAPKCS1KeyExchangeDeformatter = New RSAPKCS1KeyExchangeDeformatter(rsaer)
                    Dim key() As Byte = def.DecryptKeyExchange(keyex)
                    Dim iv() As Byte = New Byte((sa.IV.Length - 1)) {}
                    Buffer.BlockCopy(encrbytes, keyex.Length, iv, 0, iv.Length)
    
                    Dim ct As ICryptoTransform = sa.CreateDecryptor(key, iv)
                    result = ct.TransformFinalBlock(encrbytes, keyex.Length + iv.Length, (encrbytes.Length - 1) - (keyex.Length + iv.Length))
                Catch ex As Exception
                    Throw New CryptographicException("Unable to decrypt: " + ex.Message)
                End Try
    
                Return result
            End Function	
    		
            Friend Shared Function GetAlgorithmName(ByVal typo As Algorithms) As String
                Dim algtype As String = String.Empty
    
                Select Case typo
                    Case Algorithms.DES
                        Return "DES"
                        Exit Select
                    Case Algorithms.RC2
                        Return "RC2"
                        Exit Select
                    Case Algorithms.RDAEL
                        Return "Rijndael"
                        Exit Select
                    Case Algorithms.TDES
                        Return "TripleDES"
                        Exit Select
                    Case Else
                        Return "Rijndael"
                        Exit Select
                End Select
    
                Return algtype
            End Function
    		
            Friend Shared Function ReadKeyString(ByVal xmlkeystring As String) As RSA
                Dim rsaer As RSA = Nothing
    
                Try
                    If (String.IsNullOrEmpty(xmlkeystring)) Then Throw New Exception("Key is not specified")
                    rsaer = RSA.Create()
                    rsaer.FromXmlString(xmlkeystring)
                Catch ex As Exception
                    Throw New CryptographicException("Unable to load key")
                End Try
    
                Return rsaer
            End Function	
    		
    End Namespace
