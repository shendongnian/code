    if (rButtonFind.Checked) {
       int counter = 0;
       string line;
       string filename = @"F:\Quality\CMM Fixtures\fixtures.txt";
       System.IO.StreamReader file = new System.IO.StreamReader(filename);
       if (new FileInfo(filename).Length == 0) {
          MessageBox.Show("There is no data in the file to search." + "\n" + "There must be at least one fixture" + "\n" + " to not see this message.");
       } else {
          bool found = false;
          while ((line = file.ReadLine()) != null) {
             if (line.Contains(txtID.Text)) {
                lbOne.Items.Add(line);
                found = true;
                break;
             }
          }
          if (!found) {
             lbOne.Items.Add(txtID.Text + " does not exist.");
             counter++;
          }
       }
       file.Close();
    }
