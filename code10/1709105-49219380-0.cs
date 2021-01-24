        for (int i = 0; i < arr.Count; i++)
        {
            if (command1 == i)
            {
                for (int j = 2; j < commands.Length; j++)
                {
                    copy.Add(int.Parse(commands[j]));
                }
                copy.Add(arr[i]);
            }
            else
            {
                copy.Add(arr[i]);
            }
        }
