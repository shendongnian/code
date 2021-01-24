	private static Vector2[] ConvertVector2(Vector2[] values)
	{
		var maxX = float.MinValue;
		var maxY = float.MinValue;
		var minX = float.MaxValue;
		var minY = float.MaxValue;
		foreach (var point in values)
		{
			maxX = Mathf.Max(point.x, maxX);
			minX = Mathf.Min(point.x, minX);
			maxY = Mathf.Max(point.y, maxY);
			minY = Mathf.Min(point.y, minY);
		}
		
		var result = new Vector2 [4]
		{
			new Vector2(minX, minY),
			new Vector2(maxX, maxY),
			new Vector2(maxX, minY),
			new Vector2(minX, maxY),
		};
		return result;
	}
		
	private static Vector3[] ConvertVector3(Vector3[] values) =>
       ConvertVector2(
          values.Select(v => new Vector2(v.X, v.Y)).ToArray()) // Convert to 2D
       .Select(v => new Vector3(v.X, v.Y, values[0].Z))
       .ToArray();
