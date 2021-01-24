      string root = @"S:\directory\";
            string folder = "root folder";
            DateTime lookbackDate = DateTime.Now.AddMonths(-6);
            string messageText = "";
            messageText += String.Format("We're looking for files that have been made since {0}", lookbackDate);
            MessageBox.Show(messageText); messageText += "\n";
            messageText += ("Starting directory search now\n");
            MessageBox.Show(messageText); messageText += "\n";
            string[] dirs = Directory.GetDirectories(root, folder, SearchOption.AllDirectories);
            foreach (string dir in dirs)
            {
                messageText += String.Format("Directory found! {0}", dir);
                MessageBox.Show(messageText); messageText += "\n";
                foreach (string file in Directory.GetFiles(dir))
                {
                    DateTime filedate = File.GetCreationTime(file);
                    string fname = Path.GetFileName(file);
                    if (filedate >= lookbackDate)
                    {
                        messageText += String.Format("MATCH! {0} - created {1}", fname, filedate);
                        MessageBox.Show(messageText); messageText += "\n";
                    }
                    else
                    {
                        messageText += String.Format("TOO OLD! {0} - created {1}", fname, filedate);
                        MessageBox.Show(messageText); messageText += "\n";
                    }
                }
            }
            messageText += ("\nDirectory search complete!");
            MessageBox.Show(messageText);
