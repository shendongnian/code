    private void cmdMaxCompressPNG_Click(object sender, EventArgs e) 
    {
        pbStatus.Maximum = lstFiles.Items.Count;
        var FileList = Load_Listbox_Data();
        foreach (var FileName in FileList) 
        {
            //Only thing that needs to run in the background
            await Task.Run(()=>ShellandWait("optipng.exe", String.Format("\"{0}\"", FileName));
            //Back in the UI
            pbStatus.Value += 1;
        }
    };
    lstFiles.Items.Clear();
    pbStatus.Value = 0;
    MessageBox.Show(text: "Task Complete", caption: "Status Update");
