	var data = new List<int>();
	var iterator = data.Where(x => 1 == 1);
	var type = iterator.GetType();
	var sourceField = type.GetField("source", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
	Console.WriteLine(sourceField.FieldType);
