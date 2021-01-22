    Imports System.Net
    
    Public Class WebClient2
        Inherits System.Net.WebClient
    
        Private _ClientCertificates As New System.Security.Cryptography.X509Certificates.X509CertificateCollection
        Public ReadOnly Property ClientCertificates() As System.Security.Cryptography.X509Certificates.X509CertificateCollection
            Get
                Return Me._ClientCertificates
            End Get
        End Property
        Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
            Dim R = MyBase.GetWebRequest(address)
            If TypeOf R Is HttpWebRequest Then
                Dim WR = DirectCast(R, HttpWebRequest)
                If Me._ClientCertificates IsNot Nothing AndAlso Me._ClientCertificates.Count > 0 Then
                    WR.ClientCertificates.AddRange(Me._ClientCertificates)
                End If
            End If
            Return R
        End Function
    End Class
