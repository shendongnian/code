    private void saveTSMI_Click(object sender, EventArgs e)
    {
        if (lstStudNames.Items.Count == 0)
        {
            MessageBox.Show("Nothing to save");
            return;
        }
        SaveFileDia.Filter = "Text Files | *.txt";
        if (SaveFileDia.ShowDialog() != DialogResult.OK)
        {
            return;
        }
        // Create the file (overwrite if it already exists),
        // and write each student record.
        using (var outFile = File.CreateText(SaveFileDia.FileName))
        {
            foreach (Stud student in StudentList)
            {
                outFile.WriteLine("Name: " + student.Name);
                outFile.WriteLine("Subject: " + student.Subject);
                outFile.WriteLine("Age: " + student.age);
                outFile.WriteLine("Grade: " + student.Grade);
            }
        }
    }
