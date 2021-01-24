    public static IQueryable<IFilterEntity> FilterEntity(this BaseViewModel vm,
     IQueryable<IFilterEntity> list)
    {
		return list.Where(s => s.Name == vm.name && 
                               s.DateMonth == vm.Month &&
                               s.DateYear == vm.Year);
	}
