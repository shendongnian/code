     static void Main()
    {
        // Create a dictionary and add several elements to it.
        var dict = new Dictionary<string, int>();
        dict.Add("cat", 2);
        dict.Add("dog", 3);
        dict.Add("x", 4);
        // Create another dictionary.
        var dict2 = new Dictionary<string, int>();
        dict2.Add("cat", 2);
        dict2.Add("dog", 3);
        dict2.Add("x", 4);
        // Test for equality.
        bool equal = false;
        if (dict.Count == dict2.Count) // Require equal count.
        {
            equal = true;
            foreach (var pair in dict)
            {
                int value;
                if (dict2.TryGetValue(pair.Key, out value))
                {
                    // Require value be equal.
                    if (value != pair.Value)
                    {
                        equal = false;
                        break;
                    }
                }
                else
                {
                    // Require key be present.
                    equal = false;
                    break;
                }
            }
        }
        Console.WriteLine(equal);
    }
