    public string GetConstNameByValue(string constValue)
	{
	    if (ConstClass.Const1 == constValue)
		    return nameof(ConstClass.Const1);
	    if (ConstClass.Const2 == constValue)
		    return nameof(ConstClass.Const2);
	    if (ConstClass.Const3 == constValue)
		    return nameof(ConstClass.Const3);
		throw new ArgumentException("There is no constants with expectedValue", nameof(constValue));
	}
