            for (int i = 0; i < 1000000; i++)
            {
                tupleKeyDict.Add(new Tuple<int, int>(i,0),i.ToString() );
            }
            System.Diagnostics.Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string e1 = tupleKeyDict[new Tuple<int, int>(0, 0)];
            string e2 = tupleKeyDict[new Tuple<int, int>(500000, 0)];
            string e3 = tupleKeyDict[new Tuple<int, int>(999999, 0)];
            stopWatch.Stop();
            Console.WriteLine("Tuplekey cost(tick): " + stopWatch.ElapsedTicks.ToString());
            Console.WriteLine("Tuplekey cost(ms): " + stopWatch.ElapsedMilliseconds.ToString());
            
            var strKeyDict = new Dictionary<string, string>();
            for (int i = 0; i < 1000000; i++)
            {
                strKeyDict.Add(i.ToString() + ":0", i.ToString());
            }
            System.Diagnostics.Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            string se1 = strKeyDict["0:0"];
            string se2 = strKeyDict["500000:0"];
            string se3 = strKeyDict["999999:0"];
            stopWatch2.Stop();
            Console.WriteLine("strkey cost(tick): " + stopWatch2.ElapsedTicks.ToString());
            Console.WriteLine("strkey cost(ms): " + stopWatch2.ElapsedMilliseconds.ToString());
            
            var intKeyDict = new Dictionary<int, string>();
            for (int i = 0; i < 1000000; i++)
            {
                intKeyDict.Add(i, i.ToString());
            }
            System.Diagnostics.Stopwatch stopWatch3 = new Stopwatch();
            stopWatch3.Start();
            string ie1 = intKeyDict[0];
            string ie2 = intKeyDict[500000];
            string ie3 = intKeyDict[999999];
            stopWatch3.Stop();
            Console.WriteLine("intkey cost(tick): " + stopWatch3.ElapsedTicks.ToString());
            Console.WriteLine("intkey cost(ms): " + stopWatch3.ElapsedMilliseconds.ToString());
