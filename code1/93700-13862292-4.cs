    <%@ Page Language="VB" Debug="True" EnableViewState="True" %>
    <%@ Import Namespace="System.Data" %>
    <%@ Import Namespace="System.Data.OleDb" %>
    <script runat="server">
      Sub Page_Load(sender as Object, e as EventArgs)
       If Not Page.IsPostBack
          BindData() ' Only binds the data on the first page load
       End If
      End Sub
    '''''''******BEGIN OF DB DATA DISLAY IN DATAGRID
      Sub BindData()
        '1. Create a connection
        Const strConnStr as String = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=c:\inetpub\protected\Comments.mdb"
        Dim objConn as New OleDbConnection(strConnStr)
        objConn.Open()
      
    '2. Create a command object for the query
        Const strSQL as String = "SELECT ID, Ethnicity, Username, Comments FROM tblMsgNotes"
        Dim objCmd as New OleDbCommand(strSQL, objConn)
      
    '3. Create/Populate the DataReader
        Dim objDR as OleDbDataReader
        objDR = objCmd.ExecuteReader()    
      
        dgComments.DataSource = objDR
        dgComments.DataBind()   
      End Sub
    '''''''******END OF DB DATA DISLAY IN DATAGRID
    '''*************BEGIN OF EDIT, UPDATE, CANCEL BUTTONS
    'Sub dgComments_Edit(sender As Object, e As DataGridCommandEventArgs)
    '    dgComments.EditItemIndex = e.Item.ItemIndex
    '    BindData()
    'End Sub
    'Sub dgComments_Cancel(sender As Object, e As DataGridCommandEventArgs)
    '    dgComments.EditItemIndex = -1
    '    BindData()
    'End Sub
    'Sub dgComments_Update(sender As Object, e As DataGridCommandEventArgs)
    '   'Read in the values of the updated row
    '   Dim usrID00 as Integer = e.Item.Cells(1).Text
    '   Dim strethnic00 as String = CType(e.Item.Cells(2).Controls(0), TextBox).Text
    '   Dim strusrname00 as String = CType(e.Item.Cells(3).Controls(0), TextBox).Text
    '   Dim strcommnts00 as String = CType(e.Item.Cells(4).Controls(0), TextBox).Text
    ''Construct the SQL statement using Parameters
    '    Dim strSQL as String = _
    '      "UPDATE [tblMsgNotes] SET [Ethnicity] = @ethnic00, " & _
    '      "[Username] = @usrname00, [Comments] = @commnt00 " & _
    '      "WHERE [ID] = @usrID"
    '    Const strConnString as String = _
    '       "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\inetpub\protected\Comments.mdb"
    '    Dim objConn as New OleDbConnection(strConnString)
    '    objConn.Open()
    '    Dim myCommand as OleDbCommand = new OleDbCommand(strSQL, objConn)
    '    myCommand.CommandType = CommandType.Text'
    '    ' Add Parameters to the SQL query
    ''    Dim parameterProdName as OleDbParameter = _
    ''               new OleDbParameter("@ProdName", OleDbType.VarWChar, 75)
    ''    parameterProdName.Value = strName
    ''    myCommand.Parameters.Add(parameterProdName)'
    '    Dim parameterethnic00 as OleDbParameter = _
    '               new OleDbParameter("@ethnic00", OleDbType.VarWChar, 75)
    '    parameterethnic00.Value = strethnic00
    '    myCommand.Parameters.Add(parameterethnic00)'
    ''    Dim parameterUnitPrice as OleDbParameter = _
    ''               new OleDbParameter("@UnitPrice", OleDbType.Currency)
    ''    parameterUnitPrice.Value = dblPrice
    ''    myCommand.Parameters.Add(parameterUnitPrice)
    '    Dim parameterusrname00 as OleDbParameter = _
    '               new OleDbParameter("@usrname00", OleDbType.VarWChar, 75)
    '    parameterusrname00.Value = strusrname00
    '    myCommand.Parameters.Add(parameterusrname00)
    ''    Dim parameterProdDesc as OleDbParameter = _
    ''               new OleDbParameter("@ProdDesc", OleDbType.VarWChar)
    ''    parameterProdDesc.Value = strDesc
    ''    myCommand.Parameters.Add(parameterProdDesc)
    '    Dim parametercommnts00 as OleDbParameter = _
    '               new OleDbParameter("@commnts00", OleDbType.VarWChar, 75)
    '    parametercommnts00.Value = strcommnts00
    '    myCommand.Parameters.Add(parametercommnts00)
    ''    Dim parameterProdID as OleDbParameter = _
    ''               new OleDbParameter("@ProductID", OleDbType.Integer)
    ''    parameterProdID.Value = iProductID
    ''    myCommand.Parameters.Add(parameterProdID)
    '    Dim parameterusrID00 as OleDbParameter = _
    '               new OleDbParameter("@usrID00", OleDbType.Integer)
    '    parameterusrID00.Value = usrID00
    '    myCommand.Parameters.Add(parameterusrID00)
    '    myCommand.ExecuteNonQuery()   'Execute the UPDATE query
    '    objConn.Close()   'Close the connection
    '    'Finally, set the EditItemIndex to -1 and rebind the DataGrid
    '    dgComments.EditItemIndex = -1
    '    BindData()
    'End Sub
    '''*************END OF EDIT, UPDATE, CANCEL BUTTONS
    </script>
