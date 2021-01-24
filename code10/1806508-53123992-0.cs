            DataTable dt = new DataTable();
            using (System.IO.StreamReader sr = new System.IO.StreamReader("PathToFile"))
            {
                string currentline = string.Empty;
                bool doneHeader = false;
                while ((currentline = sr.ReadLine()) != null)
                {
                    if (!doneHeader)
                    {
                        foreach (string item in currentline.Split('YourDelimiter'))
                        {
                            dt.Columns.Add(item);
                        }
                        doneHeader = true;
                        continue;
                    }
                    dt.Rows.Add();
                    int colCount = 0;
                    foreach (string item in currentline.Split('YourDelimiter'))
                    {
                        dt.Rows[dt.Rows.Count - 1][colCount] = item;
                        colCount++;
                    }
                }
            }
