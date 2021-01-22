    if (control == null) 
    { for (int i = 0; i < page.Request.Form.Count; i++) 
        { 
            if ((page.Request.Form.Keys[i].EndsWith(".x")) || (page.Request.Form.Keys[i].EndsWith(".y"))) 
                 { control = page.FindControl(page.Request.Form.Keys[i].Substring(0, page.Request.Form.Keys[i].Length - 2)); break; 
                 }
         }
     } 
