    private void Form1_Load(object sender, EventArgs e) {
        string appName = Environment.CurrentDirectory;
        int l = appName.Length;
        int h = appName.LastIndexOf("bin");
        string ll = appName.Remove(h);                
        string g = ll + "Resources\\sample.txt";
        System.Diagnostics.Process.Start(g);
    }
