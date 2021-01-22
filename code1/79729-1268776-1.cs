    protected void TestSubmit_ServerClick(object sender, EventArgs e)
    {
        using (StreamWriter w = new StreamWriter(Server.MapPath("~/data.txt"), true))
        {
            w.WriteLine(TextBox1.Text); // Write the text
        }
    }
