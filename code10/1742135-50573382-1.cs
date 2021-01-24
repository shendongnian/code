    public async Task<List<Technology>> Get() {
        var data = dbContext.Set<Technology>().Select(x=> new Technology{
            Id = x.Id,
            Name = x.Name,
            Intern= new Intern {
                 Id = x.Technology.Id,
                 Name = x.Technology.Name,
                 Technologies = null
            }
        });
        return await data.ToListAsync();
    }
