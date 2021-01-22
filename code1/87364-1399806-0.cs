    public class BasePage: System.Web.UI.Page {
      // I've tended to create overloads of this that take just an href and type 
      // for example that allows me to use this to add CSS to a page dynamically
      public void AddHeaderLink(string href, 
                                string rel, 
                                string type, 
                                string media) {
        HtmlLink link = new HtmlLink();
        link.Href = href;
        // As I'm working with XHTML, I want to ensure all attributes are lowercase
        // Also, you could replace the length checks with string.IsNullOrEmpty if 
        // you prefer.
        if (0 != type.Length){
          link.Attributes.Add(HtmlTextWriterAttribute.Type.ToString().ToLower(),
                              type);
        }
        if (0 != rel.Length){
          link.Attributes.Add(HtmlTextWriterAttribute.Rel.ToString().ToLower(),
                              rel);
        }
        if (0 != media.Length){
          link.Attributes.Add("media", media);
        }
        Page.Header.Controls.Add(link);
      }
    }
