    <%@ Page Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASP_Test_WebApp.Default" %> 
    <asp:Content id="TEST" ContentPlaceHolderID="Main" Runat="Server" >
        <asp:label runat="server" id="MyLabel"/>
    </asp:content>
    public partial class Default: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyLabel.Text = "StackOverflow rocks!"
        }
    }
