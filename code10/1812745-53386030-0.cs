    [HttpGet]
    public IEnumerable<CarViewModel> Get()
    {
        IEnumerable<CarViewModel> list =
            this.mapper.Map<IEnumerable<CarViewModel>>(this.dbContext.cars.AsEnumerable());
        return list;
    }
