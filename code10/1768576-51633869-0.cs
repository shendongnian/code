                List<string> customBindingRow = new List<string>();
                List<List<string>> customBindingData = new List<List<string>>();
                for (int i = 0; i < 10; i++)
                {
                    customBindingRow = new List<string>();
                    for (int j = 0; j < 2; j++)
                    {
                        customBindingRow.Add("i=" + i.ToString() + "j=" + j.ToString());
                    }
    
                    customBindingData.Add(customBindingRow);
                }
