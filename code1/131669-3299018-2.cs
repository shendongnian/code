    <%@ Page Title="" Language="C#" 
        MasterPageFile="~/Views/Shared/Site.Master" 
        Inherits="System.Web.Mvc.ViewPage<MyNamespace.Models.MainEntity>" %>
    ....
    <%Html.RenderPartial("ucMyUserControl",Model.AssociatedEntity);
    ....
    
