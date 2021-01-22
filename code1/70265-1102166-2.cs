    Imports System.Data
    Imports System.Data.SqlClient
    Imports System.Configuration
    
    Public Class DataRelation
      Inherits System.Web.UI.Page
      Protected lblDisplay As System.Web.UI.WebControls.Label
      Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objConn As SqlConnection
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        Dim dtrParent As DataRow
        Dim dtrChild As DataRow
    
        objConn = New SqlConnection(ConfigurationSettings.Appsettings("NorthwindConnection"))
        da = New SqlDataAdapter("SELECT * FROM Categories", objConn)
        ds = New DataSet()
        Try
          objConn.Open()
          da.Fill( ds,"Categories")
          da.SelectCommand = New SqlCommand("SELECT * FROM Products", objConn)
          da.Fill(ds, "Products")
        Catch exc As SqlException
          Response.Write(exc.ToString())
        Finally
          objConn.Dispose()
        End Try 
        'Create the Data Relationship
        ds.Relations.Add("Cat_Prod",ds.Tables("Categories").Columns("CategoryID"), _
                                ds.Tables("Products").Columns("CategoryID"))
        'Display the Category and Child Products Within
        For each dtrParent in ds.Tables("Categories").Rows
          lblDisplay.Text &= "<h3>" & dtrParent("CategoryName") & "</h3><ul>"
          For each dtrChild in dtrParent.GetChildRows("Cat_Prod")
            lblDisplay.Text &= "<li>" & dtrChild("ProductName") & "</li>"
          Next
          lblDisplay.Text &= "</ul>"
        Next
      End Sub
    End Class 
