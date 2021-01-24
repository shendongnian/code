    else
                {
                    var someVariable = DbContext.DbSet<>.AsNoTracking().Where(
                    m =>
                        m.Some_ID == CurrentlyEditingSomeID
                    ).AsQueryable().OrderByDescending(m => m.End_Date); 
                    return someVariable;
                }
