	class DispatchTable
	{
		readonly Action[] _actions;
		public DispatchTable(params Action[] actions)
		{
			_actions = actions;
		}
		public void Execute(ulong actionsMask)
		{
			for (int bitIx = 0; bitIx < _actions.Length && actionsMask != 0; bitIx++, actionsMask >>= 1)
			{
				if ((actionsMask & 0x01) != 0)
					_actions[bitIx]();
			}			
		}
		static void Main(string[] args)
		{
			DispatchTable t = new DispatchTable(
				delegate() { Console.WriteLine(1); },
				delegate() { Console.WriteLine(2); },
				delegate() { Console.WriteLine(3); }
			);
			t.Execute(0x04);
			t.Execute(0x02);
			t.Execute(0x01);
			t.Execute(0x0F);
		}
	}
