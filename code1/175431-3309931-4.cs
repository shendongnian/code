    public void notifyObservers()
	{
		for (Observer o: observers)
		{
			o.update();  // this will call the View update below since it is an Observer
		}
	}
 
