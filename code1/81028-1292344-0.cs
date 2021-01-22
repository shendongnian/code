    public static class MyCoolExtension
    {
      public static string TextBox(this HtmlHelper htmlHelper, string name)
      {
         // get data from htmlHelper.ViewData and call another extension methods of the HtmlHelper 
        var className = htmlHelper.ViewData["someClass"];
        return htmlHelper.TextBox("myField", "30", new { @class = className });
      }
    }
