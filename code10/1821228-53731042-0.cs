                ... 
                if(File.Exists(target))
                {
                    if (MessageBox.Show("The File you want to copy already exists. Do you want to replace it?", "File exists", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        File.Delete(target);
                        File.Copy(path, target, false);
                        GoToDirectory();
                    }
                }
                else
                {
                    File.Copy(path, target, false);
                    GoToDirectory();
                }
                ...
