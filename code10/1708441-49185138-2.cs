    private Random random = new Random();
    private string testFilePath = @"c:\users\nor asyraf mohd no\documents\testfile.txt";
    private List<string> testFileLines;
    private void Form1_Load(object sender, EventArgs e)
    {
        if (!File.Exists(testFilePath))
        {
            MessageBox.Show($"The file does not exist: {testFilePath}");
        }
        else
        {
            try
            {
                testFileLines = File.ReadAllLines(testFilePath).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not read file {testFilePath}. Exception details: {ex}");
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (testFileLines != null && testFileLines.Count > 0)
        {
            var randomLine = testFileLines[random.Next(testFileLines.Count)];
            Label1.Text = randomLine;
            testFileLines.Remove(randomLine);
        }
    }
