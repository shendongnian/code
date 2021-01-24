    using (StreamReader fileInput = File.OpenText("Assignment5.txt"))
        {
            //Add null operator here
            String[] line = fileInput.ReadLine()?.Split(',');
            while (line != null)//read each line
            {
                cards.Add(new CreditCard(line[0], double.Parse(line[1]), double.Parse(line[2])));
                //Add nulls operators here
                line = fileInput.ReadLine()?.Split(',');
            }
        }
