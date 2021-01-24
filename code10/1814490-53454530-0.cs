    private void btnSave_Click(object sender, EventArgs e)
    {
        using (System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(@"D:\List.txt"))
        {
            foreach (var item in listBox.Items)
            {
                SaveFile.WriteLine(item.ToString());
            }
        }
    }
