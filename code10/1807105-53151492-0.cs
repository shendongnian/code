	class B:A
	{
		string name;
		public B()
		{
			// hidden from debugger
			name = "11"
			
			// here's where the debugger is told the constructor starts
			name = "22";
		}
	}
