	else if (type.IsArray) 
	{ 
		Type typeElement = Type.GetType(type.FullName.Replace("[]", string.Empty)); 
		var array = obj as Array; 
		Array copiedArray = Array.CreateInstance(typeElement, array.Length); 
		for (int i = 0; i < array.Length; i++) 
		{ 
			// Get the deep clone of the element in the original array and assign the  
			// clone to the new array. 
			copiedArray.SetValue(CloneProcedure(array.GetValue(i)), i); 
		} 
		return copiedArray; 
	} 
