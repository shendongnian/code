    List<string> s = new List<string>();
            s.Add("StudentA, Math, Mrs.Jones, Sixth, 98, 92, 90, , 40");
            s.Add("StudentB, Science, Mrs.Williams, Second, , 91, 70, 50, 41");
            s.Add("StudentC, History, Mr.Webber, Eighth, 100, 92, 90, 75, 40");
            s.Add("StudentD, Art, Mrs.Gonzalez, Fourth, 99, 91, 85,, 40");
            foreach (var item in s)
            {
                    string[] studentSplit = item.Split(',');
                studentSplit.Where(x => x.Trim().Length==0).ToList().ForEach(y=>studentSplit[Array.LastIndexOf(studentSplit, y)]="0");
                    
            }
