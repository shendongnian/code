	public Ext.Net.MVC.PartialViewResult ListSubData(int id)
	{
		return new Ext.Net.MVC.PartialViewResult
		{
			RenderMode = RenderMode.AddTo,
			Model = id,
			ContainerId = "MyContainerId",
			WrapByScriptTag = false
		};
	}
