	public ActionResult DoSomething(string action, string param1, string param2)
	{
		switch (action)
		{
			case "update":
				return UpdateAction(param1, param2);
			case "remove":
				return DeleteAction(param1);
		}
	}
