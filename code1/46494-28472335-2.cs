   
     static void Main( string[] args )
    		{
    			foreach (var element in SampleEnum.GetAll())
    			{
    				Console.WriteLine( "{0}: {1}", element, element.AdditionalText );
    				Console.WriteLine( "Is 'Element2': {0}", element == SampleEnum.Element2 );
    				Console.WriteLine();
    			}
    
    			Console.ReadKey();
    		}
