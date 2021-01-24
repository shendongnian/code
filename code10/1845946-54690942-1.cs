protected void Button2_Click(object sender, EventArgs e)
{
    lblanything.Text = Session["id"].ToString();
}
protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
{
    GridViewRow row = GridView1.SelectedRow;
    Session["id"] = row.Cells[3].Text;
}
Hope it'll resolve your issue. 
