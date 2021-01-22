            List<List<string>> listOfLists = new List<List<string>>();
            
            List<string> list1 = new List<string>();
            list1.Add("elem 1 1");
            list1.Add("elem 1 2");
            list1.Add("elem 1 3");
            List<string> list2 = new List<string>();
            list2.Add("elem 2 1");
            list2.Add("elem 2 2");
            list2.Add("elem 2 3");
            list2.Add("elem 2 4");
            
            listOfLists.Add(list1);
            listOfLists.Add(null); // list can contain nulls
            listOfLists.Add(list2);
            listOfLists.Add(null); // list can contain nulls
