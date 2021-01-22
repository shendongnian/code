    Response.Clear();
    Response.ContentType = mimeType;
    Response.AddHeader("Content-Disposition", String.Format("attachment; filename=\"{0} {1} Report for Week {2}.pdf\"", ddlClient.SelectedItem.Text, ddlCollectionsDirects.SelectedItem.Text, ddlWeek.SelectedValue));
    Response.BinaryWrite(bytes);
    Response.Flush();
    Response.End();
