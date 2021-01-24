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
				Type type;
				if (isList(value)) type = field.FieldType.GetGenericArguments().Single();
				else type = field.FieldType.GetElementType();
				var castMethod = this.GetType().GetMethod("CastList").MakeGenericMethod(type);
				value = castMethod.Invoke(null, new object[] { value });
			}
			field.SetValue(GameData.save, value);
		});
		GameData.Save();
	}
