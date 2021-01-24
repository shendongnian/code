    private void TestList()
            {
                List<SomeObject> lst = new List<SomeObject>();
                //Add to the list
                lst.Add(new SomeObject("Mary", "Jones", 50));
                lst.Add(new SomeObject("John", "Smith", 42));
                lst.Add(new SomeObject("James", "Peterson",50));
                lst.Add(new SomeObject("Mary", "Hanes", 62));
                //Sort the list
                var sortedByAge = from obj in lst orderby obj.Age select obj;
                Debug.Print("*****List Sorted by Age*****");
                foreach (SomeObject obj in sortedByAge)
                    Debug.Print($"{obj.FirstName} {obj.LastName}'s age is {obj.Age}");
                var sortByLastName = from obj in lst orderby obj.LastName select obj;
                Debug.Print("*****List Sorted by LastName*****");
                foreach (SomeObject obj in sortByLastName)
                    Debug.Print($"{obj.LastName}, {obj.FirstName}");
                //Delete from list
                for (int i = lst.Count - 1; i > -1; i--)
                    if (lst[i].FirstName == "Mary")
                    { lst.RemoveAt(i); }
                Debug.Print("*****List after Deletes*****");
                foreach (SomeObject item in lst)
                    Debug.Print($"{item.FirstName} {item.LastName} {item.Age}");
            }
            public class SomeObject
            {
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public int Age { get; set; }
                public SomeObject(string fname, string lname, int age)
                {
                    FirstName = fname;
                    LastName = lname;
                    Age = age;
                }
            }
