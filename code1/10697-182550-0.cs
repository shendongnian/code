    try // wrap everything in a try/catch to handle things I haven't thought of
    {
        if ( !dr.Table.Columns.Contains("column") )
        {
            throw new SomeSortOfException("cloumn: " + column + " is missing" );
        }
        else // strictly don't need the else but it makes the code easier to follow
        {
            if (dr["column"].Equals(DBNull.Value))
            {
                this.value= null;
            }
            else
            {
                this.value = (type) dr["column"];
            }
        }
    }
    catch( SomeSortOfException ex )
    {
        throw;
    }
    catch( Exception ex )
    {
        // handle or throw impossible exceptions here
    }
