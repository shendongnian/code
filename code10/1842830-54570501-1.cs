    MSWord.Application application;
    private void button1_Click(object sender, EventArgs e)
    {
        if (application == null)
        {
            application = new MSWord.Application();
            application.Visible = true;
        }
        var document = OpenDocument(application, @"d:\test.docx");
        // ...
    }
