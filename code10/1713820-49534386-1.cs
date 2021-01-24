    private void contextMenuStripOpenInSqlStudio_Click(object sender, EventArgs e)
    {
        saveProcToAFile();
        Process openSQL = new Process();
        openSQL.StartInfo.FileName = "Ssms.exe";
        openSQL.StartInfo.Arguments = "procedureToBeLoaded.sql";
        openSQL.Start();
    } 
