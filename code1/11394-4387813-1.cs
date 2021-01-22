    private void SortGridGenerico< T >(
              ref List< T > lista		
    	, SortDirection sort
    	, string propriedadeAOrdenar)
    {
    
    	if (!string.IsNullOrEmpty(propriedadeAOrdenar)
    	&& lista != null
    	&& lista.Count > 0)
    	{
    
    		Type t = lista[0].GetType();
    
    		if (sort == SortDirection.Ascending)
    		{
    
    			lista = lista.OrderBy(
    				a => t.InvokeMember(
    					propriedadeAOrdenar
    					, System.Reflection.BindingFlags.GetProperty
    					, null
    					, a
    					, null
    				)
    			).ToList();
    		}
    		else
    		{
    			lista = lista.OrderByDescending(
    				a => t.InvokeMember(
    					propriedadeAOrdenar
    					, System.Reflection.BindingFlags.GetProperty
    					, null
    					, a
    					, null
    				)
    			).ToList();
    		}
    	}
    }
