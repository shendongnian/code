            List<dynamic> lst= new List<dynamic>();
			int n;
			Console.Write ( "\n\nSort elements of array in ascending order :\n" );
			Console.Write ( "----------------------------------------------\n" );
			Console.Write ( "Input the size of array : " );
			n = Convert.ToInt32 ( Console.ReadLine ( ) );
			Console.Write ( "Input {0} elements in the array :\n", n );
			for (var  i = 0; i < n; i++ )
			{
				Console.WriteLine ( "Enter name {0}", i );
				var name = Console.ReadLine ( );
				Console.Write ( "element - {0} : ", i );
				var elem = Convert.ToInt32 ( Console.ReadLine ( ) );
				lst.Add ( new { name = name, elem = elem } );
			}
			Console.Write ( "\nElements of array in sorted ascending order:\n" );
	
			lst.OrderBy ( t => t.elem ).ToList ( ).ForEach ( y => {
				Console.Write ( "{0}, {1}  ", y.elem, y.name );
			} );
			Console.Write ( "\n\n" );
			Console.ReadLine ( );
