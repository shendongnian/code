    Ex:
   
     public class MainEntity
        {
        public MainEntity()
        {
        AssociatedEntity = new SubEntity(); // This is where the instantiation happen.
        }
        public SubEntity AssociatedEntity;
        }
        public class SubEntity
        {
        public string property1;
        }
        
    Your View Page :
    
    <%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyNamespace.Models.MainEntity>" %>
    ....
    <%Html.RenderPartial("ucMyUserControl",Model.AssociatedEntity);
    ....
    
    Your User Control:
    <%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MyNamespace.Models.SubEntity>" %>
    ....
    <%Html.TextBoxFor(m=>m.Property1);
