			ValueWrapper<bool> wrappedBool = new ValueWrapper<bool>(true);
			
			bool unwrapped = wrappedBool;  // you can assign it direclty:
						
			if (wrappedBool) { // or use it how you'd use a bool directly
				// ...
			}
   	public class ValueWrapper<T>
	{
		public T Value { get; set; }
		public ValueWrapper() {	}
		public ValueWrapper(T value) { 
            this.Value = value;	
        }
		public static implicit operator T(ValueWrapper<T> wrapper)
		{
			if (wrapper == null) {
				return default(T);
			}
			return wrapper.Value;
		}
	}
