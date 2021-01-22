    public void Accept(ExceptionVisitor visitor)
    {
    	Read(this.exception, visitor);
    }
    
    private static void Read(Exception ex, ExceptionVisitor visitor)
    {
    	bool isRoot = ex.InnerException == null;
    	if (isRoot)
    	{
    		visitor.VisitRootCause(ex);
    	}
    
    	visitor.Visit(ex);
    	visitor.Depth++;
    
    	bool isAggregateException = TestComplexExceptionType<AggregateException>(ex, visitor, aggregateException => aggregateException.InnerExceptions);
    	TestComplexExceptionType<ReflectionTypeLoadException>(ex, visitor, reflectionTypeLoadException => reflectionTypeLoadException.LoaderExceptions);
    
    	// aggregate exceptions populate the first element from InnerExceptions, so no need to revisit
    	if (!isRoot && !isAggregateException)
    	{
    		visitor.VisitInnerException(ex.InnerException);
    		Read(ex.InnerException, visitor);
    	}
    
    	// set the depth back to current context
    	visitor.Depth--;
    }
    
    private static bool TestComplexExceptionType<T>(Exception ex, ExceptionVisitor visitor, Func<T, IEnumerable<Exception>> siblingEnumerator) where T : Exception
    {
    	var complexException = ex as T;
    	if (complexException == null)
    	{
    		return false;
    	}
    
    	visitor.VisitComplexException(ex);
    
    	foreach (Exception sibling in siblingEnumerator.Invoke(complexException))
    	{
    		visitor.VisitSiblingInnerException(sibling);
    		Read(sibling, visitor);
    	}
    
    	return true;
    }
