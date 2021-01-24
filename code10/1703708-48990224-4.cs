	for (int i = 0; i < 5; i++)
	{
		var asset = new AssetModel();
		asset.AssetId = new Guid().ToString();
		asset.Description = $"Asset { i + 1} ";
		asset.TaskDetailList = new List<TaskDetail>();
		for (int j = 0; j < 3; j++)
			asset.TaskDetailList.Add(new TaskDetail() { Description = $"Detail { (i + 1) } - { (j + 1) }" });
		var group = new Grouping<AssetModel, TaskDetail>(asset, asset.TaskDetailList);
		AssetsList.Add(group);
	}
