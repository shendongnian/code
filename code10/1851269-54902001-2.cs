    grp.ForEach(g => 
    {
        int stepNumber = 0;
        int step = 2;
        var target = g.Skip(stepNumber * step).Take(step);
    
        if (target.Sum(x => x.Field<decimal>("amount")) != 0)
        {
            // Move to B
        }
    
        stepNumber ++;
    });
