    public class SQLObjectManager<TEntity> where TEntity : class, new()
    {
    	public TEntity GetObject(int year, int stateID)
    	{
    		if( /* entity found in cache */)
    			return GetFromCache(year,stateID);
    		if( /* entity found in db */)
    			return GetFromDB(year,stateID);
    		TEntity entity = new TEntity();
    		entity.Year = year;
    		entity.StateID = stateID;
    		return entity;
    	}
    }
