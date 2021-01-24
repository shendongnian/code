    public void Add<T>(T entity)
    {
        var fieldIWant = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(p => p.FieldType == typeof(IList<T>)).SingleOrDefault();
        if (fieldIWant != null) {
			var value = (IList<T>)fieldIWant.GetValue(this);
			value.Add(entity);
		}
    }
