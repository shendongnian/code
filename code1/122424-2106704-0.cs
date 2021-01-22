    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IQueryable<Models.Benefit>>" %>
    
    <% foreach(Benefit benefit in Model){ %>
        <% Html.RenderPartial("Benefit", benefit); %>
    <% } %>
