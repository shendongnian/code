	using (context.ReadUnCommitted())
	{
        get1 = _context.Get1(param);
		// throw new NotImplementedException();
        get2 = _context.Get2(param);
	}
    get3 = _context.Get3(param);
