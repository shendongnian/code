        Dictionary<int, string>[] matrix = new Dictionary<int, string>[10];
        int id = 0; // Number here
        int index = id % 10;
        if (matrix[index] == null)
        {
            matrix[index] = new Dictionary<int, string>();
        }
        int key = 0; // key you want to insert
        if (matrix[index].ContainsKey(key))
        {
            // Dictionary already has this key. handle this the way you want
        }
        else
        {
            matrix[index].Add(0, ""); // Key and value here
        }
