    HtmlGenericControl span = new HtmlGenericControl("span");
    // or Literal1
    String contents = span.InnerHtml; //  OR  Literal1.Text ; 
    StringBuilder formattedText;            
    
    int len = contents.Length;    
    
     for (int i = 0; i < len; i += 1)
     {  
    
        if ( i == BreakLimit )
    	    formattedText.Append(  "<br />") ;
        else 
    	    formattedText.Append(  contents[i])  ;
     }
     Literal1.Text = formattedText.ToString();
}
