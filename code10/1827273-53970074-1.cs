    public List<DTO> GetData()
    {
        return query.Select(x= > new DTO() 
                     {
                       PropA = x.SomeColumn,
                       ...........
                       ...........
                     }).ToList();
    }
