    <%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Models.Project>" %>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <% using (Html.BeginForm()) { %>
            <% Html.RenderPartial("~/Views/Home/SearchTemplate.ascx", Model.Search); %>
            <input type="submit" value="Create" />
        <% } %>
    </asp:Content>
