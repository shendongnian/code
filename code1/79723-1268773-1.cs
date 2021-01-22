    protected void TestSubmit_ServerClick(object sender, EventArgs e)
    {
        StreamWriter _testData = new StreamWriter(Server.MapPath("~/data.txt", true);
        _testData.WriteLine(TextBox1.Text); // Write the file.
        _testData.Flush();
        _testData.Close(); // Close the instance of StreamWriter.
        _testData.Dispose(); // Dispose from memory.       
    }
