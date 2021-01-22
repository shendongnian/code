    MessageBox.Show("The File is Create in The Place Of The Programe If you Don't Write The Place Of copy And You write Only Name Of Folder");// It Is To Help The User TO Know
              if (Fromtb.Text=="")
            {
                MessageBox.Show("Ples You Should Write All Text Box");
                Fromtb.Select();
                return;
            }
            else if (Nametb.Text == "")
            {
                MessageBox.Show("Ples You Should Write The Third Text Box");
                Nametb.Select();
                return;
            }
            else if (Totb.Text == "")
            {
                MessageBox.Show("Ples You Should Write The Second Text Box");
                Totb.Select();
                return;
            }
            string fileName = Nametb.Text;
            string sourcePath = @"" + Fromtb.Text;
            string targetPath = @"" + Totb.Text;
            
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
                //when The User Write The New Folder It Will Create 
                MessageBox.Show("The File is Create in "+" "+Totb.Text);
            }
            System.IO.File.Copy(sourceFile, destFile, true);
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);
                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                   
                }
                MessageBox.Show("The File is copy To " + Totb.Text);
            }
 
