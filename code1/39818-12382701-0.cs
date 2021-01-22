    <ServiceContract(Namespace:="")> _
    <AspNetCompatibilityRequirements
    (RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)> _
    Public Class PersonService
        <OperationContract()> _
        Public Sub DoWork()
            ' Add your operation implementation here
        End Sub
        ' Add more operations here and mark them with <OperationContract()>
        
       <OperationContract()> _
       Public Sub SetSessionVariable(ByVal Sessionkey As String)
            System.Web.HttpContext.Current.Session("Key") = Sessionkey
            System.Web.HttpContext.Current.Session.Timeout = 20
        End Sub
        <OperationContract()> _
        Public Function GetSessionVariable() As String
            Return System.Web.HttpContext.Current.Session("Key")
        End Function
        
    End Class
