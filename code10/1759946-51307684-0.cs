    StreamReader sr1 = new StreamReader("C:\\Users\\moki\\Downloads\\Input.csv");
    DataTable mydata = new DataTable();
    string[] arr;
            using (sr1)
            {
                while (sr1.EndOfStream == false)
                {
                    string line = sr1.ReadLine();
                    if (line != null && line != String.Empty)
                    {
                         arr = line.Split(';');
                         
                         mydata.Rows.Add();
                           
                         for (int j = 1; j < arr.Length; j++)
                            {
                                if (arr[j] != "")
                                {
                                    mydata.Rows[i][j] = arr[j];
                                }
                            }
                      }
                  }
               }
                      
