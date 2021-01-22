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
                    else
                    {
                       // Huh? Should this happen, maybe some logging can go here to track down why you couldn't just use the .Convert()
                    }
                }
                objectReader.Close();
        
            }
            else
            {
                MessageBox.Show("No Such File" + filename);
            }
        }
