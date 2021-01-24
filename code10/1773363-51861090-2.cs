	private static ICollection<ICollection<MyClass>> GetBatches(ICollection<MyClass> toBatch, int sizeOfBatch)
    {
		var output = new List<ICollection<MyClass>>();
		
		if(sizeOfBatch > toBatch.Count) sizeOfBatch = toBatch.Count;
		
		var numBatches = toBatch.Count / sizeOfBatch;
		for(int i = 0; i < numBatches; i++){
			output.Add(toBatch.Skip(i * sizeOfBatch).Take(sizeOfBatch).ToList());
		}
		
		return output;
	}
