    using(TextReader tr = new StreamReader("c1.txt")) {
        string line;
        while((line = tr.ReadLine()) != null) {
            string[] fields = line.Split('|');
            string name = fields[0];
            decimal price = Decimal.Parse(fields[1]);
            Console.WriteLine(
                String.Format("Name = {0}, Price = {1}", name, price)
            );
        }
    }
