            List<string> list = new List<string>();
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");
            string[] values = new string[list.Count];//assigning the count for array
            for(int i=0;i<list.Count;i++)
            {
                values[i] = list[i].ToString();
            }
