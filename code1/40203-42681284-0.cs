		private void TestBench()
		{
			// An object to test
			string[] stringEnumerable = new string[] { "Easy", "as", "Pi" };
			ObjectListFromUnknown(stringEnumerable);
		}
		private void ObjectListFromUnknown(object o)
		{
			if (typeof(IEnumerable<object>).IsAssignableFrom(o.GetType()))
			{
				List<object> listO = ((IEnumerable<object>)o).ToList();
				// Test it
				foreach (var v in listO)
				{
					Console.WriteLine(v);
				}
			}
		}
