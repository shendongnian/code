    Imports Microsoft.Web.Services3
    Imports Microsoft.Web.Services3.Addressing
    Imports Microsoft.Web.Services3.Messaging
    
    Namespace Logic
        Public Class HTTPClient
            Inherits Soapclient
    
            Sub New(ByVal destination As EndpointReference)
                MyBase.Destination = destination
            End Sub
    
            <SoapMethod("processConfirmation")> _
            Public Function processConfirmation(ByVal envelope As SoapEnvelope) As SoapEnvelope
                Return MyBase.SendRequestResponse("processConfirmation", envelope)
            End Function
        End Class
    End Namespace
