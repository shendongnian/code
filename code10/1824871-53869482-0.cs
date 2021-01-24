    string zipProgramPath = @"C:\Program Files\7-Zip\7z.exe";
    
    public Form1()
    {
        InitializeComponent();
    }
    public void CreateZipFile(string sourceName, string targetName)
    {
        try
        {
            ProcessStartInfo zipProcess = new ProcessStartInfo();
            zipProcess.FileName = zipProgramPath; // select the 7zip program to start
            zipProcess.Arguments = "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -mx=9";
            zipProcess.WindowStyle = ProcessWindowStyle.Minimized;
            zipProcess.UseShellExecute = true;
            Process zip = Process.Start(zipProcess);
            zip.WaitForExit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    private void btnBrowseSource_Click(object sender, EventArgs e)
    {
        using (var fbd = new FolderBrowserDialog())
        {
            DialogResult result = fbd.ShowDialog();
    
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                lblSource.Text = fbd.SelectedPath; //label next to the button
            }
        }
    
    }
    private void btnBrowseTarget_Click(object sender, EventArgs e)
    {
        using (var fbd = new FolderBrowserDialog())
        {
            DialogResult result = fbd.ShowDialog();
    
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                lblTarget.Text = fbd.SelectedPath.ToString(); //label next to the button
            }
        }
    }
    
    private void btnExecute_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(lblSource.Text) || string.IsNullOrEmpty(lblTarget.Text))
        {
            MessageBox.Show("Choose input directory and output directory");
        }
        else
        {
            foreach (var folder in Directory.GetDirectories(lblSource.Text))
            {
                string folderName= Path.GetFileName(folder);
                string targetName = Path.Combine(lblTarget.Text, folderName+ ".7z" );
                CreateZipFile(folder, targetName);
            }
        }
    }
