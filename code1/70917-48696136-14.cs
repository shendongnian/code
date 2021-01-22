    using static my_globals;
	public enum TestEnum { A, B, C };
    static void CompareExchangeEnum()
    {
	    var e = TestEnum.A;
	    if (CmpXchg(ref e, TestEnum.B, TestEnum.A) != TestEnum.A)
		    throw new Exception("change not accepted");
    }
