    columnDefinition.Width = new GridLength(50); //Hard coded to 50
    columnDefinition.Width = new GridLength(50, GridUnitType.Star); //dividend of remaining space allocated at 50.
    //In other words; any other Star values will be divided in Width based on the remaining Grid size and the Star value given.
    //A star value of 25* in another ColumnDefinition will make it half the length of the 50* and a value of 100* will make it twice the 50* or the 50* half of the 100*.
    //Either way you look at it; the total remaining Width of the space provided by the panel gets divided out to the Star Columns and the dividend they get is based on their portion of the Star.  50* for all Columns will make them all equal.
    columnDefinition.Width = GridLength.Auto; //Adjusts to the remaining width dynamically.
