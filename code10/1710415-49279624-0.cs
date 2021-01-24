    public class QuantityDropDown : Control
    {
       public int Quantity {get;set;}
       protected override void Render (HtmlTextWriter writer)
       {
           writer.Write("<select>");
           for (int i=0; i < Quantity; i++)
           {
               write.Write("<option>" + i.ToString() + "</option>");
           } 
           writer.Write("</select>");
       }
    }
