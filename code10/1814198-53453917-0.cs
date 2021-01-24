            ObservableCollection<Person> inputlist = (ObservableCollection<Person>)value;
            List<string> PossibleColumnList = new List<string>();
            PossibleColumnList.Add(nameof(Person.Name)); //since we need name header first.
            List<string> TempColumnList = new List<string>();
            foreach (Person P in inputlist)
            {
               foreach(Treat T in P.Treats)
                {
                    if (TempColumnList.Contains(T.Name) == false) TempColumnList.Add(T.Name);
                }
            }
            TempColumnList.Sort();
            PossibleColumnList.AddRange(TempColumnList); //This way we get Name first and rest of the columns in sorted out manner
