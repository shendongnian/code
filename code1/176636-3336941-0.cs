    using (var creatingThing = new MyCreatingThing())
    {
    	try
    	{
        creatingThing.CreateSomething();
        }
        catch(Exception ex)
        {
            creatingThing.Rollback();
        }
    }
