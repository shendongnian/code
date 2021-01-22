    private class MyClass<T> where T : new()
	{
			private void AMethod()
			{
				T myVariable = new T();
			}
	}
