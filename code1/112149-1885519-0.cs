        public void Numbers(string filename)
        {
            List<float> myList = new List<float>();     
            string input;
            if (System.IO.File.Exists(filename) == true)
            {
                System.IO.StreamReader objectReader;
                objectReader = new System.IO.StreamReader(filename);
                while ((input = objectReader.ReadLine()) != null)
                {
                    Single output;
                    if (Single.TryParse(input, out output ))
                    {
                        myList.Add(output);
                    }
                }
                objectReader.Close();
        
            }
            else
            {
                MessageBox.Show("No Such File" + filename);
            }
        }
