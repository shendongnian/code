            foreach (int i in list1)
            {
                string output = "";
                foreach (KeyValuePair<var, string> kvp in yourDictionary)
                {
                    if (kvp.Value.Contains(i.ToString()))
                    {
                        output += kvp.Value + ", ";
                    }
                }
                //print your outputstring here.
            }
