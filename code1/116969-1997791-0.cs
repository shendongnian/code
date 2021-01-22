public partial class Site : System.Web.Mvc.ViewMasterPage<SiteViewData>
{
}
> `SiteViewData` contains:
> 
public class SiteViewData 
{
  public String Title { get; set; } 
}
> Each page `ViewData` class inherits from the `SiteViewData` class and looks something like this
> 
public class IndexViewData : SiteViewData
{
  public String Message { get; set; }
  public String SupportedLanguages {get; set;}
}
> This approach allows one to write code in the `Site.Master` page as follows
> 
<title><%= Html.Encode(ViewData.Model.Title) %></title>
> Unfortunately, when an exception is thrown, the model has been replaced with an instance of the `HandleErrorInfo` class. This causes an `InvalidOperationException` to be thrown with the information
> The model item passed into the dictionary is of type `System.Web.Mvc.HandleErrorInfo` but this dictionary requires a model item of type `Igwt.Boh.Website.Web.Controllers.SiteViewData`.
> Is it possible for a new `ErrorData` property to be added to the `ViewResult` class to store the instance of the `HandleErrorInfo` class instead? This way the `ViewData` does not get changed.
> Chances are pretty good that any exception thrown in the action will occur after the `IndexViewData` (and `SiteViewData`) properties have already been initialized.
> Closed Jan 27, 2010 at 12:24 AM by 
> Won't fix - see comments.
