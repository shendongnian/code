    private void Form1_Load(object sender, EventArgs e)
    {
        var path = System.IO.Path.GetTempFileName();
        System.IO.File.Delete(path);
        System.IO.Directory.CreateDirectory(path);
        var indexPath = System.IO.Path.Combine(path, "index.html");
        var scriptPath = System.IO.Path.Combine(path, "script.js");
        System.IO.File.WriteAllText(indexPath, Properties.Resources.index);
        System.IO.File.WriteAllText(scriptPath, Properties.Resources.script);
        webBrowser1.Navigate(indexPath);
    }
