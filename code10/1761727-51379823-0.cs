    public T DoSomething(Func<TestingDatabaseEntities, T> func)
    {
        try
        {
         using ( var context = new TestingDatabaseEntities() )
            {
                // Any database action
                return func(context);
            }
        }
        catch (DbEntityValidationException)
        {
            // Error handling
        }
        catch(DbUpdateException)
        {
            // Error handling
        }
        catch (InvalidOperationException)
        {     
            // Error handling
        }
        catch (EntityException)
        {
            // Error handling
        }
    }
