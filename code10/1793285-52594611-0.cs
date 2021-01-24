            ObservableCollection<Class1> test = new ObservableCollection<Class1>();
            Class1 obj = new Class1("Maria", 22203);
            test.Add(obj);
            List<Class1> v = test.Where(x => x.Name == "Maria").ToList();
            foreach (Class1 c in v)
            {
                test.Remove(c); //Also works
            }
