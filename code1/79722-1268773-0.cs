    protected void TestSubmit_ServerClick(object sender, EventArgs e)
    {
        StreamWriter _testData = new StreamWriter(Server.Mappath("~/data.txt", true);
        _testData.WriteLine(TextBox1.Text); // Write the file.
        _testData.Flus();
        _testData.Close(); // Close the instance of StreamWriter.
        _testData.Dispose(); // Dispose from memory.       
    }
