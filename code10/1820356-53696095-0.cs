    private void supsearchtxt_TextChanged(object sender, EventArgs e)
        {
            listsup.Items.Clear();
            Supfile = System.AppDomain.CurrentDomain.BaseDirectory + "data\\Suppliers.txt";
            List<string> proName = new List<string>();
            using (StreamReader rdr = new StreamReader(Supfile))
            {
                string line;
                while ((line = rdr.ReadLine()) != null)
                {
                    if (line.Contains(supsearchtxt.Text))
                    {
                        string[] val = line.Split(',');
                        listsup.Items.Add(val[0]);
                    }
                }
            }
            
        }
