	static void Main()
	{
		var counter = new CountingClass();
		var firstIterator = counter.CountingEnumerator();
		Console.WriteLine("First list");
		firstIterator.MoveNext();
		Console.WriteLine(firstIterator.Current);
	
		Console.WriteLine("First list cloned");
		var secondIterator = EnumeratorCloner.Clone(firstIterator);
		
		Console.WriteLine("Second list");
		secondIterator.MoveNext();
		Console.WriteLine(secondIterator.Current);
		secondIterator.MoveNext();
		Console.WriteLine(secondIterator.Current);
		secondIterator.MoveNext();
		Console.WriteLine(secondIterator.Current);
	
		Console.WriteLine("First list");
		firstIterator.MoveNext();
		Console.WriteLine(firstIterator.Current);
		firstIterator.MoveNext();
		Console.WriteLine(firstIterator.Current);
	}
	
	public class CountingClass
	{
		public IEnumerator<int> CountingEnumerator()
		{
			int i = 1;
			while (true)
			{
				yield return i;
				i++;
			}
		}
	}
	
	public static class EnumeratorCloner
	{
		public static T Clone<T>(T source) where T : class, IEnumerator
		{
			var sourceType = source.GetType().UnderlyingSystemType;
			var sourceTypeConstructor = sourceType.GetConstructor(new Type[] { typeof(Int32) });
			var newInstance = sourceTypeConstructor.Invoke(new object[] { -2 }) as T;
	
			var nonPublicFields = source.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
			var publicFields = source.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
			foreach (var field in nonPublicFields)
			{
				var value = field.GetValue(source);
				field.SetValue(newInstance, value);
			}
			foreach (var field in publicFields)
			{
				var value = field.GetValue(source);
				field.SetValue(newInstance, value);
			}
			return newInstance;
		}
	}
