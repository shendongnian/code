    protected override void RenderContents(HtmlTextWriter output)  
    {  
       StringBuilder sb = new StringBuilder();  
       HtmlTextWriter htw = new HtmlTextWriter(new System.IO.StringWriter(sb,   
       System.Globalization.CultureInfo.InvariantCulture));  
       foreach (Control ctrl in Controls)  
       {  
          ctrl.RenderControl(htw);  
       }  
      string strContents = sb.ToString();  
   }  
