    public string NameSort { get; set; }
    public string DateSort { get; set; }    
        
    public async Task OnGetAsync(string sortOrder)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            IQueryable<Log> logsEntry = from s in _context.Log
                                            select s;
            switch (sortOrder)
            {
                case "name_desc":
                    logsEntry = logsEntry.OrderByDescending(l => l.Name);
                    break;
                case "Date":
                    logsEntry = logsEntry.OrderBy(l => l.Date);
                    break;
                case "date_desc":
                    logsEntry = logsEntry.OrderByDescending(l => l.Date);
                    break;
                default:
                    logsEntry = logsEntry.OrderBy(l => l.Date);
                    break;
            }
            Log = await logsEntry.AsNoTracking().ToListAsync();
        }
