	using System;
    
	namespace Internal
	{
		public class Eng
        {
            internal void Foo(Action<DB> act) => act(new DB());
        }
        internal class DB
        {
            internal void Wiz()
            {
                Console.WriteLine("Hello, World!");
            }
        }
    }
