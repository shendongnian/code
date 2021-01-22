    Public Class JSONHelper
    Public Shared Function Serialize(Of T)(ByVal obj As T) As String
        Dim JSONserializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()  
        Return JSONserializer.Serialize(obj)
    End Function
    Public Shared Function Deserialize(Of T)(ByVal json As String) As T
        Dim obj As T = Activator.CreateInstance(Of T)()
        Dim JSONserializer As System.Web.Script.Serialization.JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer()
        obj = JSONserializer.Deserialize(Of T)(json)
        Return obj
    End Function
    End Class
