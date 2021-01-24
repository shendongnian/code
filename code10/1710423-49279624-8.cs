    
    [ToolboxData("<{0}:QuantityDropDown runat=\"server\"></{0}:QuantityDropDown >")]
    public class QuantityDropDown : Control
    {
       public int Quantity {
           get { return (int)(ViewState["Quantity"] ?? default(int)); }
           set {ViewState["Quantity"] = value;}
       }
       protected override void Render (HtmlTextWriter writer)
       {
           writer.RenderBeginTag(HtmlTextWriterTag.Select);
           for (int i=0; i < Quantity; i++)
           { 
               writer.AddAttribute("value", i);
               writer.RenderBeginTag(HtmlTextWriterTag.Option);
               writer.Write(i.ToString());
               writer.RenderEndTag();
           } 
           writer.RenderEndTag();
           writer.WriteLine();
       }
    }
