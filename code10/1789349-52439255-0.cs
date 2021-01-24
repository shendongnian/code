            string line;
            List<Employee> lstEmpDetails = new List<Employee>();
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"d:\read.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                lstEmpDetails.Add(new Employee(words[0].ToString(), int.Parse(words[1]), decimal.Parse(words[2]), double.Parse(words[3])));
            }
            file.Close();
