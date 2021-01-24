    private void Button1_OnClick(object sender, EventeArgs e)
    {
        
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "inline; filename=MyFile.pdf");
    Response.TransmitFile(myselect.SelectedValue.ToString());
    Response.End();
    }
