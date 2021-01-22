            List<int> test = new List<int>();
            test.Add(1);
            test.Add(2);
            test.Add(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);
            test.Add(7);
            test.Add(8);
            for (int i = test.Count-1; i > -1; i--)
            {
                if(someCondition){
                    test.RemoveAt(i);
                }
            }
