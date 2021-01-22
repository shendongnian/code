        string attachment = "attachment; filename=Export.xls";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        // Create a form to contain the grid
        HtmlForm frm = new HtmlForm();
       gv.Parent.Controls.Add(frm);
        frm.Attributes["runat"] = "server";
        frm.Controls.Add(gv);
        frm.RenderControl(htw);
 
        //GridView1.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
