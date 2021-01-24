    public Expression<Func<AnswerSetType, SomeClass>> SomeMethod()
    {
	    if (condition)
    	{
	    	return (answerSetType => new SomeClass { ValueFromColumn1OrColumn2 = answerSetType.Column1 });
    	}
	    else
    	{
	    	return (answerSetType => new SomeClass { ValueFromColumn1OrColumn2 = answerSetType.Column2 });
    	}
    }
