    public class ThemeController : Controller{
      public ActionResult ThemeDropDown(){
         return PartialView(new ThemeViewModel(){ SelectedTheme = ..., ThemeList = ... })
      }
    }
    public class AppleController : Controller{
      public ActionResult AppleStuff(){
         return PartialView(new AppleViewModel(){ Apple = ..., AppleList = ... })
      }
    }
    
    
    <%= Html.RenderAction("ThemeDropDown", "Theme") %>    
    <%= Html.RenderAction("AppleStuff", "Apple") %>
