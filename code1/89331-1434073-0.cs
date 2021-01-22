    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MyProject.Areas.HelpDesk.Models.hd_Ticket>>" %>
    <%@ Import Namespace="MyProject.Areas.HelpDesk.Controllers" %>
    <%@ Import Namespace="MvcContrib.Pagination" %>
    
    <h2>Help Desk Tickets (showing <%= Model.Count() %> of <%= ViewData["totalItems"] %>)</h2>     
    
    <% foreach (var item in Model) { %>
    	<h3><%= Html.Encode(item.Subject)%></h3>
    <% } %>
    
    <p><%= Html.Pager((IPagination)Model)%></p>
