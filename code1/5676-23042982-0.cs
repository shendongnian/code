    T t = new T();
    T t2 = (T)t;  //eh something like that
    
            List<myclass> cloneum;
            public void SomeFuncB(ref List<myclass> _mylist)
            {
                cloneum = new List<myclass>();
                cloneum = (List < myclass >) _mylist;
                cloneum.Add(new myclass(3));
                _mylist = new List<myclass>();
            }
