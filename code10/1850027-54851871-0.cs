    private object _lockObject = new object();
    public async Task<bool> Bar()
    {
       //setup object to be inserted to database
        try
        {
            // lock your changes, so they run in a safe order
            lock (_lockObject)
            {
                //the table can not have auto incrememnt so we read the max value
                objectToBeAdded.id = Context.Set<object>().Max(o => o.id) + 1;
                await Context.Set<object>().AddAsync(objectToBeAdded);
                await Context.SaveChangesAsync();
            }
            return true;
        }
        catch (Exception ex) {
            return false;
        }
    }
