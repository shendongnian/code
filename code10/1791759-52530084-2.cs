		public class aclass
		{
			private string _athing;
			public string Athing 
			{
					get { return _athing; }
					set { _athing = value; }
			}
		}
		public void example(string thing)
		{
			aclass aclass = new aclass();
			aclass.Athing = thing;
		}
