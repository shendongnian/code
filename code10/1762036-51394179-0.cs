    public static void DirSearch(string strDir)
            {
                try
                {
                    foreach (string strDirectory in Directory.
                        GetDirectories(strDir))
                    {
                        //do something
                        DirSearch(strDirectory);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
