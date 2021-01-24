    If(some comparison)
    {
       // if we get here we obviously made a comparison and it was true
       Comparisons +=1;
    }
    else if (some comparison)
    {
       // If we get here we obviously made 2 comparisons
       // the first was false, this is true. 
       // However regardless, 2 Comparisons were made 
       Comparisons +=2;
    }
    else
    {
       // if we get here we obviously made 2 comparisons both were false
       // however 2 comparisons were still made 
       Comparisons +=2;
    }
