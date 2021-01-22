	XElement OrderStatus(q_order_status Request)
	{
	  try
	  { 
		if (DoSomething() != 0 )
		{
		  return null;
		}
		else
		{
		  return new XElement("SomeTag", "SomeResponse");
		}
	  }
	  catch(Exception e)
	  {
		// catch some errors and eventually pass the e.Message to the Response
		return new XElement(e.tag, e.response);
	  }
	}
