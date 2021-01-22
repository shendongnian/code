    protected void btnExportExl_Click(object sender, EventArgs e)
    {
    	grd.Allowpaging = false;
    	grd.DataBind(); // you need to rebind the gridview
    	grd.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    	
    	grd.Allowpaging = true;//Again do paging to gridview
    	grd.DataBind();
    }
