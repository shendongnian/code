		static void Main(string[] args) {
			foreach (System.Reflection.PropertyInfo propertyInfo in typeof(System.Collections.ArrayList).GetProperties()) {
				System.Reflection.ParameterInfo[] parameterInfos = propertyInfo.GetIndexParameters();
				// then is indexer property
				if (parameterInfos.Length > 0) {
					System.Console.WriteLine(propertyInfo.Name);
				}
			}
			System.Console.ReadKey();
		}
