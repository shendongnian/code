    private void Form1_Load(object sender, EventArgs e)
    {
         string fileName = @"C:\Users\Public\TestFolder\WriteText.txt";
         string text = System.IO.File.ReadAllText(fileName);
         richTbWrite.Text = text;
    }
    
    private void btnApply_Click(object sender, EventArgs e)
    {
         string fileName = @"C:\Users\Public\TestFolder\WriteText.txt";
         string content = richTbWrite.Text;
         System.IO.File.WriteAllText(fileName, content);
    }
