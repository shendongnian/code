c#
    public class ScriptsHelper 
    {
       public IHtmlString Render(params string[] scripts) 
       {
          return Styles.Render(scripts);
       }
    }
You can then add those helper classes to your `HtmlTemplateBase<T>` class as public properties
c#
    [RequireNamespaces("System.Web.Mvc.Html")]
    public class HtmlTemplateBase<T>:TemplateBase<T>, IViewDataContainer
    {
        public ScriptsHelper Scripts = new ScriptsHelper();
    
        //... Additional Code 
    }
Your RazorEngine view will now have access to the functions you have added to your helper class. So you are indirectly calling the functions you need and can call them the same way you would use the normal classes.
c#
// This will actually be calling ScriptsHelper.Scripts(), which then calls the static function
@Scripts.Render("~/scripts/scripturl")
These are somewhat hacky solutions to the issue. You will need to extend your `ScriptsHelper` class with each `Scripts` function that you need. The same process can be performed for your `Styles` class as well. 
You may be able to utilize the [Reference Resolver class][2] to import the System.Web.Optimization namespace, but I wasn't able to get that working properly.
  [1]: https://stackoverflow.com/a/19434112/3338349
  [2]: https://antaris.github.io/RazorEngine/ReferenceResolver.html
