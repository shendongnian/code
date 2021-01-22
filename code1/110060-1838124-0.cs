		public void M<T> (out T c) where T : Test
		{
			// Test m;
			// A(out m);
			// c = (T) m;
			A(out c);
		}
		public void A<T> (out T t) where T : Test
		{
			t = null;
		}
