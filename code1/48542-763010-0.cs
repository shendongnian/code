    //PLEASE COMMENT IF YOU FIND BUGS OR SUGGEST IMPROVEMENTS
			using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.Reflection;
			namespace MustHaveAttributes
			{
				[AttributeClass ( "Yordan Georgiev", "1.0.0" )]	
				class Program
				{
				
					
					static void Main ( string [] args )
					{
						bool flagFoundCustomAttrOfTypeAttributeClass = false; 
						Console.WriteLine ( " START " );
						// what is in the assembly
						Assembly a = Assembly.Load ( "MustHaveAttributes" );
						Type[] types = a.GetTypes ();
						foreach (Type t in types)
						{
							object[] arrCustomAttributes = t.GetCustomAttributes ( true );
							
							if (arrCustomAttributes == null || arrCustomAttributes.GetLength ( 0 ) == 0)
							{
								//DO NOT CHECK IN
								ExitProgram ( t, "Found class without CustomAttributes" );
							}
							foreach (object objCustomAttribute in arrCustomAttributes)
							{
								Console.WriteLine ( "CustomAttribute for type  is {0}", t );
								if (objCustomAttribute is AttributeClass)
									flagFoundCustomAttrOfTypeAttributeClass = true; 
							}
							if (flagFoundCustomAttrOfTypeAttributeClass == false)
							{ //DO NOT CHECK IN 
								ExitProgram ( t, "Did not found custom attribute of type AttributeClass" );
							}
							Console.WriteLine ( "Type is {0}", t );
						}
						Console.WriteLine ("{0} types found", types.Length );
						//NOW REQUIREMENTS IS PASSED CHECK IN
						Console.WriteLine ( " HIT A KEY TO EXIT " );
						Console.ReadLine ();
						Console.WriteLine ( " END " );
					}
					static void ExitProgram ( Type t, string strExitMsg  )
					{
						Console.WriteLine ( strExitMsg );
						Console.WriteLine ( "Type is {0}", t );
						Console.WriteLine ( " HIT A KEY TO EXIT " );
						Console.ReadLine ();
						System.Environment.Exit ( 1 );
					}
				} //eof Program
				//This will fail even to compile since the constructor requires two params
				//[AttributeClass("OnlyAuthor")]		
				//class ClassOne
				//{ 
				
				//} //eof class 
				////this will not check in since this class does not have required custom
				////attribute
				//class ClassWithoutAttrbute
				//{ }
				[AttributeClass("another author name " , "another version")]
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
