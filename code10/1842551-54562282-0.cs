	public static List<T> CastList<T>(List<object> o) {
		var list = new List<T>();
		foreach (var i in o) { list.Add((T)i); }
		return list;
	}
	void SaveDataLocal() {
		keyValues.ForEach(item => {
			var field = GameData.save.GetType().GetField(item.key);
			var value = GetValue(item);
			if (value.GetType().IsArray || isList(value)) {
				var data = new List<object>();
				if (value.GetType().IsArray) { data = ((object[])value).ToList(); } else { data = (List<object>)value; }
				var type = data[0].GetType();
				var castMethod = this.GetType().GetMethod("CastList").MakeGenericMethod(type);
				value = castMethod.Invoke(null, new object[] { value });
			}
			field.SetValue(GameData.save, value);
		});
		GameData.Save();
	}
