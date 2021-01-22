	using System;
	namespace CrazyStruct
	{
		public struct MyStruct
		{
			private readonly int _height;
			private readonly bool _init; // Will be 'false' using default(MyStruct).
			/// <summary>
			/// Height in centimeters.
			/// </summary>
			public int Height
			{
				get
				{
					if (!_init)
					{
						// Alternatively, could have the preferred default value set here.
						// _height = 200; // cm
						// _heightInit = true;
						throw new InvalidOperationException("Height has not been initialized.");
					}
					return _height;
				}
				// No set:  immutable-ish.
			}
			private MyStruct(int height)
			{
				_height = height;
				_init = true;
			}
			public static MyStruct Factory(int height)
			{
				return new MyStruct(height);
			}
		}
		static class Program
		{
			static void Main(string[] args)
			{
				MyStruct my = MyStruct.Factory(195);
				Console.WriteLine("My height is {0} cm.", my.Height);
				try
				{
					var array = new MyStruct[1];
					var ms = array[0];
					Console.WriteLine("My height is not {0} cm.", ms.Height);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Caught the expected exception: {0}.", ex);
				}
				Console.ReadKey();
			}
		}
	}
