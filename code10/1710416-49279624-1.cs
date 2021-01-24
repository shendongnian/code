    public class QuantityDropDown : Control
    {
       public int Quantity {get;set;}
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
       }
    }
