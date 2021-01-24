     object objLock = new object();
     int sum3 = 0;
     Parallel.ForEach(mArray, item =>
     {
         lock (objLock) { sum3 += item; }
     });
     Console.WriteLine("sum3 " + sum3);
