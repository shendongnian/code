            public IEnumerable<int> MyInts
            {
                get
                {
                    foreach (ClassA c in classAs)
                    {
                        foreach (int i in c.MyInts)
                        {
                            yield return i;
                        }
                    }
                }
    
            }
