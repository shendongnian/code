    StreamReader sr1 = new StreamReader("C:\\Users\\moki\\Downloads\\Input.csv");
    DataTable mydata = new DataTable();
    string[] arr;
    int i = 0;
    bool mydatasetup = false;
            using (sr1)
            {
                while (sr1.EndOfStream == false)
                {
                    string line = sr1.ReadLine();
                    if (line != null && line != String.Empty)
                    {
                         arr = line.Split(';');
                        if(mydatasetup == false)
                        {
                            for (int u = 0; u < arr.Length; u++)
                            {
                                mydata.Columns.Add();
                            }
                            mydatasetup = true;
                        } 
                         
                         mydata.Rows.Add();
                           
                         for (int j = 0; j < arr.Length; j++)
                            {
                                if (arr[j] != "")
                                {
                                    mydata.Rows[i][j] = arr[j];
                                }
                            }
                         i = i + 1;
                      }
                  }
               }
                      
