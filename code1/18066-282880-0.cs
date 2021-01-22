	using System;
	namespace ConsoleApplication1
	{
		public class foo
		{
			public int value;
		};
		public class bar
		{
			public bar()
			{
				m_foo = new foo();
				m_foo.value = 42;
			}
			private foo m_foo;
			public foo getFoo() { return m_foo; }
		};
		public class Program
		{
			public static int Main()
			{
				bar b = new bar();
				b.getFoo().value = 37;
				return 0;
			}
		};
	}
