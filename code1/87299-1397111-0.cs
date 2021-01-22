    public class MenuTree : Control
    {
       public string MenuText {get; set;}
       public List<MenuTree> Children {get; set;}
    
       public override void Render(HTMLTextWriter writer)
       {
          writer.RenderBeginTag(HtmlTextWriterTag.Ul);
          writer.RenderBeginTag(HtmlTextWriterTag.Li);
          writer.RenderBeginTag(MenuText);
          writer.RenderEndTag();
          foreach (MenuTree m in Children)
          {
             m.Render();
          }
          writer.RenderEndTag();
       }
    
       
    }
