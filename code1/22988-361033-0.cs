      var qry = from line in File.ReadAllLines(@"C:\Temp\Text.txt")
                let vals = line.Split(new char[] { ',' })
                select new
                {
                  Name = vals[0].Trim(),
                  Sex = vals[1].Trim(),
                  Birth = vals[2].Trim(),
                  m1 = Int32.Parse(vals[3]),
                  m2 = Int32.Parse(vals[4]),
                  m3 = Int32.Parse(vals[5])
                };
    
      double avg = qry.Average(a => a.m1);
      double GirlsAvg = qry.Where(a => a.Sex == "female").Average(a => a.m1);
      double BoysAvg = qry.Where(a => a.Sex == "male").Average(a => a.m1);
