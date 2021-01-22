    public void ContainTheDanger(Expression<Func<T>> dangerousCall)
    {
        try 
        {
            dangerousCall().Compile().Invoke();;
        }
        catch (Exception e)
        {
            // This next line does not work...
            var nameOfDanger = 
                ((MemberExpression)dangerousCall.Body).Member.Name;
            throw new DangerContainer(
                "Danger manifested while " + nameOfDanger, e);
        }
    }
    public void SomewhereElse()
    {
        ContainTheDanger(() => thing.CrossTheStreams());
    }
