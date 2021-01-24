    
    [ToolboxData("<{0}:QuantityDropDown runat=\"server\"></{0}:QuantityDropDown >")]
    public class QuantityDropDown : WebControl
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
           writer.WriteLine();
       }
    }
