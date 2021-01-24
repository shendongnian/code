                if (line.Contains("Test"))
                {
                    splitLine = line.Split(':');
                    txRx = splitLine.Skip(1).ToArray();   
                    testnum = new cls_test();
                    uc.listTest.Add(testnum); 
                }
