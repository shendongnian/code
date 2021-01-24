    private Random random = new Random();
    private string testFilePath = @"c:\users\nor asyraf mohd no\documents\testfile.txt";
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!File.Exists(testFilePath))
        {
            MessageBox.Show($"The file does not exist: {testFilePath}");
        }
        else
        {
            // Read all the file lines and set the Lable Text propert to a random line
            try
            {
                var fileLines = File.ReadAllLines(testFilePath);
                Label1.Text = fileLines[random.Next(fileLines.Length)];
            }
            catch (Exception e)
            {
                MessageBox.Show($"Could not read file. Exception details: {e}");
            }
        }
    }
