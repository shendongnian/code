            if (values.Length % 2 == 1)
            {
                throw new System.ArgumentException("wrong number of arguments");
            }
            KVPs = new List<KeyValuePairs<string, string>>();
            for (i = 0; i < values.Length; i += 2)
            {
                KVPs.Add(new KeyValuePair<string, string>(values[i], values[i + 1]));
            }
