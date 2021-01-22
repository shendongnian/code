&lt;%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage&lt;string&gt;" %&gt;
public ActionResult Confirm(string id)
{
   return View(id);
}
