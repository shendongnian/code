            bool bBreak = false;
            int iEnd = 13;
            ArrayList ar1 = new ArrayList();
            ar1.Add(2);
            ar1.Add(4);
            ar1.Add(5);
            ar1.Add(7);
            String s1 = " ";
            foreach (int i in ar1)
            {
                if (i == iEnd)
                {
                    s1 = "Result = " + i;
                    bBreak = true;
                }
                if (bBreak) break;
                ArrayList ar2 = new ArrayList();
                ar2.AddRange(ar1);
                ar2.Remove(i);
                foreach (int j in ar2)
                {
                    if ((i + j) == iEnd)
                    {
                        s1 = "Results = " + i + ", " + j;
                        bBreak = true;
                    }
                    if (bBreak) break;
                    ArrayList ar3 = new ArrayList();
                    ar3.AddRange(ar2);
                    ar3.Remove(j);
                    foreach (int k in ar3)
                    {
                        if (bBreak) break;
                        if ((i + j + k) == iEnd)
                        {
                            s1 = "Results = " + i + ", " + j + ", " + k;
                            bBreak = true;
                        }
                    }
                }
            }
            Console.WriteLine(s1);
