            DateTime d = DateTime.Now;
            MyClassInstance i = new MyClassInstance(0);
            for (int x = 0; x < 10000000; x++)
            {
                i.IncrementInstance();
            }
            TimeSpan td = d - DateTime.Now;
            DateTime e = DateTime.Now;
            for (int x = 0; x < 10000000; x++)
            {
                i.IncrementStatic();
            }
            TimeSpan te = e - DateTime.Now;
