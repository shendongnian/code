    StreamReader sr1 = new StreamReader("C:\\Users\\moki\\Downloads\\Input.csv");  //create the streamreader to read the input .csv
    DataTable mydata = new DataTable();  //create an empty DataTable.....
    string[] arr;                        //....and an array in which you will store the elemnets of each line
    int i = 0;                           //just a variable to help counting where you are in your data
    bool mydatasetup = false;            //a variable to check in the loop if you already added the necessary number of columns to the datatable 
            using (sr1)
            {
                while (sr1.EndOfStream == false)    //read the whole file
                {
                    string line = sr1.ReadLine();    //get a line from the file
                    if (line != null && line != String.Empty) //check if there is content in the line
                    {
                         arr = line.Split(';');    //split the line at each ";" and put the elements in the array
                        if(mydatasetup == false)   //after reading the first line add as many columns to your datatable as you will need..... 
                        {
                            for (int u = 0; u < arr.Length; u++)
                            {
                                mydata.Columns.Add();
                            }
                            mydatasetup = true; //...but only do this once (otherwise you wil have an unneccessary big datatable
                        } 
                         
                         mydata.Rows.Add();   //add a row in you datatable in which you will store the data of the line
                           
                         for (int j = 0; j < arr.Length; j++)    //go throught each element in your array and put it into your datatable
                            {
                                if (arr[j] != "")
                                {
                                    mydata.Rows[i][j] = arr[j];
                                }
                            }
                         i = i + 1; //increase the counter so that the program knows it has to fill the data from the next line into the next row of the datatable
                      }
                  }
               }
                      
