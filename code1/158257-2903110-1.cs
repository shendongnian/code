    private void button_Click(object sender, EventArgs e)
    {
        String query = queryTextBox.Text;
        Response.Redirect("SearchResults.aspx?query=" + query);
    }
