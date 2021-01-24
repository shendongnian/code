    Supfile = System.AppDomain.CurrentDomain.BaseDirectory + "data\\Suppliers.txt";
            try
            {
                StreamReader inputFile;
                inputFile = File.OpenText(Supfile);
                string lines;
                while (!inputFile.EndOfStream)
                {
                    lines = inputFile.ReadLine();
                    string[] tokens = lines.Split(',');
                    if (!listsup.Items.Contains(tokens))
                    {
                        listsup.Items.Add(tokens[0]);
                    }
                    else { listsup.Update(); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
