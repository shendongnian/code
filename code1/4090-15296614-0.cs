    public Control GetPostBackControl(Page page)
    { 
       Control control = null; 
       string ctrlname = page.Request.Params.Get("__EVENTTARGET"); 
       if ((ctrlname != null) & ctrlname != string.Empty)
          { 
             control = page.FindControl(ctrlname); 
           }
      else 
          {
            foreach (string ctl in page.Request.Form) 
               { 
                  Control c = page.FindControl(ctl); 
                  if (c is System.Web.UI.WebControls.Button) 
                      { control = c; break; }
               }
           }
    // handle the ImageButton postbacks 
    if (control == null) 
    { for (int i = 0; i < page.Request.Form.Count; i++) 
        { 
            if ((page.Request.Form.Keys[i].EndsWith(".x")) || (page.Request.Form.Keys[i].EndsWith(".y"))) 
                 { control = page.FindControl(page.Request.Form.Keys[i].Substring(0, page.Request.Form.Keys[i].Length - 2)); break; 
                 }
         }
     } 
    return control; 
    }
