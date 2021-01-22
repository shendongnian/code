		public void Foo<T>() where T : class {
			T a = default(T);
			T b = a;
			if(a == b)
				System.Diagnostics.Debug.WriteLine("");
			else
				System.Diagnostics.Debug.WriteLine("");
		}
