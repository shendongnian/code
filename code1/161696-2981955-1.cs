    <System.Web.Services.WebService()> _
    <System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <ToolboxItem(False)> _
    <ScriptService()> _
    Public Class HospitalLocationService
        Inherits System.Web.Services.WebService
        <WebMethod()> _
        <ScriptMethod()> _
        Public Function GetAll() As List(Of HospitalLocationEntity)
            Return (New HospitalLocation()).GetAll().Data
        End Function
    End Class
