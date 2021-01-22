    <%@ Master
    Language="C#"
    MasterPageFile="~/Views/Shared/Site.Master"
    Inherits="System.Web.Mvc.ViewMasterPage<MyCMS.WebSite.ViewData.ContentViewData>" %>
    ...blah blah blah...
    
    <%= string.Empty %>
    
    ...blah blah blah...
        
    <% Html.RenderPartial("ContentItemImage", Model.ContentItem); %>
