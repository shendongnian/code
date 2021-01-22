        static void ReadText()
        {
            //open the file, read it, put each line into an array of strings
            //and then close the file
            string[] text = File.ReadAllLines("c1.txt");
            //use StringBuilder instead of string to optimize performance
            StringBuilder name = null;
            StringBuilder price = null;
            foreach (string line in text)
            {
                //get the name of the product (the string before the separator "," )
                name = new StringBuilder((line.Split(','))[0]);
                //get the Price (the string after the separator "," )
                price = new StringBuilder((line.Split(','))[1]);
                //finally format and display the result in the Console
                Console.WriteLine("Name = {0}, Price = {1}", name, price);
            }
