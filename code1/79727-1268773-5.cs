    protected void TestSubmit_ServerClick(object sender, EventArgs e)
    {
      using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/data.txt"), true))
     {
      _testData.WriteLine(TextBox1.Text); // Write the file.
     }         
    }
