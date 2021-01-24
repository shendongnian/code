    int count = 0;
        string line = null;
        while ((line = reading.ReadLine()) != null)
        {
            if (line.Contains(user))
            {
                count++;
            }
        }
        if (count > 0)
        {
            Console.WriteLine(user +" found " + count +" time");
        }
        else
        {
            Console.WriteLine(user + " not found!");
        }
