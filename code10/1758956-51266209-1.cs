    private void ConvertToCSV(ListBox listBox)
            {
                string txtpath = DIRPATH + listBoxFiles.SelectedItem + ".txt";
                string csvpath = DIRPATH + listBoxFiles.SelectedItem + ".csv";
    
                // Read through rows in the text file and replace tabs with 
                // commas
    
                var lines = File.ReadAllLines(txtpath);
                var csv = lines.Select(row => string.Join(",", Format(row).Split('\t')));
    
                // Replace the .txt extention with .csv
    
                File.WriteAllLines(txtpath, csv);
                System.IO.File.Move(txtpath, csvpath);
    
                }
