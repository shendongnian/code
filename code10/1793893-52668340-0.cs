    else
                {
                    var someVariable = DbContext.DbSet<>.Where(
                    m =>
                        m.Some_ID == CurrentlyEditingSomeID
                    ).AsQueryable().OrderByDescending(m => m.End_Date); 
                    return someVariable;
                }
