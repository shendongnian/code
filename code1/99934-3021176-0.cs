    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
    <% int size = 10;
       int maxLength = 100;
       if (ViewData["size"] != null)
       {
           size = (int)ViewData["size"];
       }
       if (ViewData["maxLength"] != null)
       {
           maxLength = (int)ViewData["maxLength"];
       }
    %>
    <%= Html.TextBox("", Model, new { Size=size, MaxLength=maxLength }) %>
