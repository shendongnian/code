    static void Main()
    {
        //
        // Read in a file line-by-line, and store it all in a List.
        //
        List<int> list = new List<int>();
        using (StreamReader reader = new StreamReader("file.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(Convert.ToInt16(line)); // Add to list.
                Console.WriteLine(line); // Write to console.
            }
        }
	    int[] numbers = list.toArray();
    }
