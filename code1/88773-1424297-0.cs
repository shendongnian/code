		class MyNastyFix<T> : MyBaseClass
		{
			public T Unwrap()
			{
				//assert that T has the correct base type
				if (!typeof(T).IsSubclassOf(typeof(MyBaseClass)))
					throw new ArgumentException();
				//must use reflection to construct
				T obj = (T)typeof(T).InvokeMember(null, BindingFlags.CreateInstance, null, null, null);
				//cast to a type of MyBaseClass so we can copy our values
				MyBaseClass c = (MyBaseClass)(object)obj;
				c.SomeValue = this.SomeValue;
				return obj;
			}
		}
		public static TResult Execute<TResult>()
		{
			return something.Foo<MyNastyFix<TResult>>().Unwrap();
		}
