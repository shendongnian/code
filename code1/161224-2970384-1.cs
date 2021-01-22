    double overlap(DateTime r1s, DateTime r1e, DateTime r2s, DateTime r1e){
        DateTime t1s,t1e,t2s,t2e;
        if (rs1<rs2) //Determine which range starts first
        {
           t1s = r1s;
           t1e = r1e; 
           t2s = r2s;
           t2e = r2e; 
        }
        else
        }
           t1s = r2s;
           t1e = r2e; 
           t2s = r1s;
           t2e = r1e; 
        }
        
        if (t1e<t2s) //No Overlap
        {
            return -1;
        }
        
        if (t1e<t2e) //Partial Overlap
        }
            TimeSpan diff = new TimeSpan(t1e.Ticks - t2s.Ticks); 
        {
        else  //Range 2 totally withing Range 1
        }
            TimeSpan diff = new TimeSpan(t2e.Ticks - t2s.Ticks); 
        {
        double daysDiff = diff.TotalDays; 
        return daysDiff;
    }
