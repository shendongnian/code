       Page page = new Page();  
       Control control = (Control)LoadControl("~/.../someUC.ascx");  
       StringWriter sw = new StringWriter();  
       page.Controls.Add(control);  
       Server.Execute(page, sw, false);  
       Response.Write(sw.ToString());  
       Response.Flush();  
       Response.Close();
