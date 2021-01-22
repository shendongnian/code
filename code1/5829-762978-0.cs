	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Reflection;
	namespace MustHaveAttributes
	{
		class Program
		{
			static void Main ( string[] args )
			{
				Console.WriteLine ( " START " );
				// what is in the assembly
				Assembly a = Assembly.Load ( "MustHaveAttributes" );
				Type[] types = a.GetTypes ();
				foreach (Type t in types)
				{
					Console.WriteLine ( "Type is {0}", t );
				}
				Console.WriteLine (
					 "{0} types found", types.Length );
				#region Linq
				//#region Action
				//string @namespace = "MustHaveAttributes";
				//var q = from t in Assembly.GetExecutingAssembly ().GetTypes ()
				//        where t.IsClass && t.Namespace == @namespace
				//        select t;
				//q.ToList ().ForEach ( t => Console.WriteLine ( t.Name ) );
				//#endregion Action  
				#endregion
				Console.ReadLine ();
				Console.WriteLine ( " HIT A KEY TO EXIT " );
				Console.WriteLine ( " END " );
			}
		} //eof Program
		class ClassOne
		{ 
		
		} //eof class 
		class ClassTwo
		{ 
		
		} //eof class
		[System.AttributeUsage ( System.AttributeTargets.Class |
			System.AttributeTargets.Struct, AllowMultiple = true )]
		public class AttributeClass : System.Attribute
		{
			public string MustHaveDescription { get; set; }
			public string MusHaveVersion { get; set; }
			public AttributeClass ( string mustHaveDescription, string mustHaveVersion )
			{
				MustHaveDescription = mustHaveDescription;
				MusHaveVersion = mustHaveVersion;
			}
		} //eof class 
	} //eof namespace 
