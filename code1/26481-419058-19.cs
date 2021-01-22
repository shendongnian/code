    static void Main()
    {
        string s = "agewpsqfxyimc";
        int count = 0;
        // Group by three.
        foreach (IEnumerable<char> g in s.Chunk(3))
        {
            // Print out the group.
            Console.Write("Group: {0} - ", ++count);
            // Print the items.
            foreach (char c in g)
            {
                // Print the item.
                Console.Write(c + ", ");
            }
            // Finish the line.
            Console.WriteLine();
        }
    }
