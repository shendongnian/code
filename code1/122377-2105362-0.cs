    var terms = from t in HRSystemDB.Terminations 
                select new { Month = t.TerminationDate.Month, 
                             Year = term1.TerminationDate.Year,
                             IsHire = false };
    var hires = from emp in HRSystemDB.Persons.OfType<Employee>() 
                select new { Month = emp.HireDate.Month, 
                             Year = emp.HireDate.Year 
                             IsHire = true };
    // Now we can merge the two inputs into one
    var summary = terms.Concat(hires);
    // And group the data using month or year
    var res = from s in summary 
              group s by new { s.Year, s.Month } into g
              select new { Period = g.Key, 
                           Hires = g.Count(info => info.IsHire),  
                           Terminations = g.Count(info => !info.IsHire) }
