    class Printer<T>
    {
        public Printer<T>(IEnumerable list)
        {
            foreach (var enumerable in list)
            {
                if (list is Dictionary<T, T>) {
                    //DO STUFF
                }
            }
        }
    }
