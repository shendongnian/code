    class NewClass
    {
        public object X;
        public object Y;
    }
    
    var myList = new List<NewClass>();
    foreach (object x in GetAllX())
    {
        if (Process(x))
        {
            foreach (object y in GetAllY(x))
            {
                myList.Add(new NewClass() {
                    X = x,
                    Y = y
                });
            }
        }
    }
