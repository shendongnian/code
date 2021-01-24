    private async void BtnGenerateReport_Click(object sender, EventArgs e) {
        var items = await _db.GetFilesAndFoldersWithUniquePermissions(txtRunId.Text); //<-- 
        string json = JsonConvert.SerializeObject(items.ToArray());
        json = JToken.Parse(json).ToString(Formatting.Indented);
        //write string to file
        System.IO.File.WriteAllText(@"c:\temp\unique-files-and-folders.txt", json);
        MessageBox.Show("Completed");
    }
