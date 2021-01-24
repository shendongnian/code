    public class BaseEventClass
    {
	  public string Name;
	  public event EventHandler ProductSaveButtonEventRaised;
	  public void RaiseAnEvent(BaseEventClass thisObj)
	  {
		if (ProductSaveButtonEventRaised != null)
		{
			ProductSaveButtonEventRaised(thisObj, EventArgs.Empty);
		}
	  }
	}
    public class ViewClass : BaseEventClass
    {
	  public void LogicWhichRaiseAnEvent(string name)
	  {
		Name = name;
		base.RaiseAnEvent(this);
	  }
	}
    public class PresenterClass : BaseEventClass
    {
	  public void LogicWhichRaiseAnEvent(string name)
      {
		Name = name;
		base.RaiseAnEvent(this);
	  }
	}
