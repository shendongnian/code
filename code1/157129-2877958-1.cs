    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Geographika.Models.NotFoundModel>" %>
    
    <asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    	<%= Html.Encode(Model.ContentName) %>
    </asp:Content>
    
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
        <h2><%= Html.Encode(Model.NotFoundTitle) %></h2>
        
        <p><%= Html.Encode(Model.ApologiesMessage) %></p>
        
        <%= Html.ActionLink(Model.LinkText,Model.Action,Model.Controller) %>
        
    </asp:Content>
