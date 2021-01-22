    void MyMethod(List<T> items)
    {
    	foreach(T item in items)
    	{
    		Html.RenderPartial(item.GetType().Name, item);
    	}
    }
