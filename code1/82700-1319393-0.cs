    private void Form1_Load(object sender, EventArgs e)
        {
            string contentToReplace = "This is <a href=\"test.aspx\" alt=\"This is test content\"> hello test world</a> content";
            string pattern = @"(>{1}.*)(test)(.*<{1})";
            string output = Regex.Replace(contentToReplace, pattern, "$1<span>$2</span>$3", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            
            //output is :
            //This is <a href="test.aspx" alt="This is test content"> hello <span>test</span> world</a> content
            MessageBox.Show(output);
            Close();
        }
