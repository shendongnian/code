    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ToDD.Models.Page>" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
        Home Page
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm()) { %>
        <%-- 
        This is the important part: It will look for 
        Views/Shared/EditorTemplates/EditableContent.ascx
        and render it. You could also specify a prefix
        --%>
        <%= Html.EditorFor(page => page.Content, "Content") %>
        <input type="submit" value="create" />
    <% } %>
    </asp:Content>
