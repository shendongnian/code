    // get your original paged list
    IPagedList<Foo> pagedFoos = _repository.GetFoos(pageNumber, pageSize);
    // map to IEnumerable
    IEnumerable<Bar> bars = Mapper.Map<IEnumerable<Bar>>(pagedFoos);
    // create an instance of StaticPagedList with the mapped IEnumerable and original IPagedList metadata
    IPagedList<Bar> pagedBars = new StaticPagedList<Bar>(bars, pagedFoos.GetMetaData());
