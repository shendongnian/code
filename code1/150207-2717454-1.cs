    {
        int i = 0;
        while(i < list.Length)
        {
            {
                string val;
                list[i] = list[i]++;
                val = list[i].ToString();
                Console.WriteLine(val);
            }
            i++;
        }
    }
