    using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\Somewhere\\whatever.txt")) 
        {
            //Generate all the single lines and write them directly into the file
            for (int i = 0; i<=10000;i++)
            {
                sw.WriteLine("This is is : " + i.ToString());
            }
        }
