    private void Form1_Shown(object sender, EventArgs e)
    {
        //
        // Current OS Information
        //
        richTextBox1.Text = @"Current OS Information:";
        richTextBox1.AppendText(Environment.NewLine +
                                "Machine Name: " + Environment.MachineName);
        richTextBox1.AppendText(Environment.NewLine +
                                "Platform: " + Environment.OSVersion.Platform.ToString());
        richTextBox1.AppendText(Environment.NewLine +
                                Environment.OSVersion);
        //
        // .NET Framework Environment Information
        //
        richTextBox1.AppendText(Environment.NewLine + Environment.NewLine +
                                           ".NET Framework Environment Information:");
        richTextBox1.AppendText(Environment.NewLine +
                                "Environment.Version " + Environment.Version);
        richTextBox1.AppendText(Environment.NewLine + 
                                DA.VersionNetFramework.GetVersionDicription());
        //
        // .NET Framework Information From Registry
        //
        richTextBox1.AppendText(Environment.NewLine + Environment.NewLine +
                                           ".NET Framework Information From Registry:");
        richTextBox1.AppendText(Environment.NewLine +
                                DA.VersionNetFramework.GetVersionFromRegistry());
        //
        // .NET Framework 4.5 or later Information From Registry
        //
        richTextBox1.AppendText(Environment.NewLine + 
                                           ".NET Framework 4.5 or later Information From Registry:");
        richTextBox1.AppendText(Environment.NewLine +
                                DA.VersionNetFramework.Get45or451FromRegistry());
        //
        // Update History
        //
        richTextBox1.AppendText(Environment.NewLine + Environment.NewLine +
                                "Update History");
        richTextBox1.AppendText(Environment.NewLine + 
                                DA.VersionNetFramework.GetUpdateHistory());
        //
        // Setting Cursor to first character of textbox
        //
        if (!richTextBox1.Text.Equals(""))
        {
            richTextBox1.SelectionStart = 1;
        }
    }
