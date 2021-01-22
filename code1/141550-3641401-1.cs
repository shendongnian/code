    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SomeNs.Models.FolderViewModel>>" %>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <% foreach (var folder in Model) { %>
        <%: Html.ActionLink(Model.Id, "Bind", new { id = Model.Id }) %>
    <% } %>
    
    </asp:Content>
