	private JObject CreateObjectForPath(string target, object newValue)
	{
		var json = new StringBuilder();
		json.Append(@"{");
		var paths = target.Split('.');
		var i = -1;
		var objCount = 0;
		foreach (string path in paths)
		{
			i++;
			if (paths[i] == "$") continue;
			json.Append('"');
			json.Append(path);
			json.Append('"');
			json.Append(": ");
			if (i + 1 != paths.Length)
			{
				json.Append("{");
				objCount++;
			}
		}
		json.Append(newValue);
		for (int level = 1; level <= objCount; level++)
		{
			json.Append(@"}");
		}
		json.Append(@"}");
		var jsonString = json.ToString();
		var obj = JObject.Parse(jsonString);
		return obj;
	}
