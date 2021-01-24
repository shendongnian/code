    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        using (var context = new NotesContext())
        {
            try
            {
                return await context
                    .Tasks
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                //log ex...
                throw;
            }
        }
    }
