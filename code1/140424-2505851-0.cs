    <asp:ObjectDataSource 
        ID="__definitionCategoryDataSource" 
        runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetData" 
        TypeName="Missico.Data.DefinitionDataSetTableAdapters.DefinitionCategoryTableAdapter">
    </asp:ObjectDataSource>
----
    Protected Sub __definitionCategoryDataSource_ObjectCreated( _
        ByVal sender As Object, _
        ByVal e As System.Web.UI.WebControls.ObjectDataSourceEventArgs) _
        Handles __definitionCategoryDataSource.ObjectCreated
        If e.ObjectInstance IsNot Nothing Then
            SetObjectDataSourceConnectionString(e.ObjectInstance, DataManager.ConnectionString)
        End If
    End Sub
    Public Sub SetObjectDataSourceConnectionString( _
        ByVal objectInstance As Object, _
        ByVal connectionString As String)
        If objectInstance IsNot Nothing Then
            Dim oConnection As System.Data.Common.DbConnection
            oConnection = objectInstance.GetType.GetProperty("Connection").GetValue(objectInstance, Nothing)
            oConnection.ConnectionString = DataManager.ConnectionString
        End If
    End Sub
