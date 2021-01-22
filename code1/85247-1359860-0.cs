    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication5 {
    	internal class Program {
    		static void Main(string[] args) {
    			
    			List<someObject> myList = new List<someObject>();
    
    			myList.Add(new someObject() {
    				DontPrint = 0,
    				PrintMe = 1,
    				PrintMeToo = 2
    			});
    
    			myList.Add(new someObject() {
    				DontPrint = 0,
    				PrintMe = 4,
    				PrintMeToo = 5
    			});
    
    			myList.Add(new someObject() {
    				DontPrint = 0,
    				PrintMe = 3,
    				PrintMeToo = 8
    			});
    
    
    			string[,] myPrintables = GetPrintables(myList);
    
    			System.Console.ReadKey();
    		}
    
    		public class someObject {
    			public int DontPrint {
    				get;
    				set;
    			}
    			[ExcelAttributes( true)]
    			public int PrintMe {
    				get;
    				set;
    			}
    			[ExcelAttributes(true)]
    			public int PrintMeToo {
    				get;
    				set;
    			}
    		}
    
    		/// <summary>
    		/// 
    		/// </summary>
    		/// <typeparam name="T"></typeparam>
    		/// <param name="list"></param>
    		/// <returns>string[,] - very easy to export to excel in array operation</returns>
    		public static string[,] GetPrintables<T>(System.Collections.Generic.IList<T> list) {
    
    			List<System.Reflection.PropertyInfo> discoveredProperties = 
    				new List<System.Reflection.PropertyInfo>();
    
    			System.Type listType = typeof(T);
    
    			// first get the property infos (not on every iteration)
    			foreach (System.Reflection.PropertyInfo propertyInfo in listType.GetProperties(
    				System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)) {
    
    				// no indexers
    				if (propertyInfo.GetIndexParameters().Length == 0) {
    					ExcelAttributes[] attributes = propertyInfo.GetCustomAttributes(typeof(ExcelAttributes), true) as ExcelAttributes[];
    
    					// allowmultiple = false hence length e {0;1}
    					if (attributes != null && attributes.Length == 1) {
    
    						if (attributes[0].PrintMe) {
    							discoveredProperties.Add(propertyInfo);
    						}
    					}
    				}
    			}
    
    			int numberOfDiscoveredProperties = discoveredProperties.Count;
    
                           // can be instantiated only if there are discovered properties, but null may be returned
    			string[,] arrayItems = new string[list.Count, numberOfDiscoveredProperties];
    
    			// if we have any printables
    			if (numberOfDiscoveredProperties > 0) {
    
    				for (int iItem = 0; iItem < list.Count; iItem++) {
    
    					for (int iProperty = 0; iProperty < numberOfDiscoveredProperties; iProperty++) {
    
    						object value = discoveredProperties[iProperty].GetValue(list[iItem], null);
    						// value.ToString may not be ideal, perhaps also cache StringConverters
    						arrayItems[iItem, iProperty] = value != null ? value.ToString() : string.Empty;
    					}
    
    				}
    			}
    
    			return arrayItems;
    		}
    	}
    
    	[System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    	public class ExcelAttributes : System.Attribute {
    
    		// use readonly field
    		private readonly bool _PrintMe;
    
    		public ExcelAttributes(bool printMe) {
    			_PrintMe = printMe;
    		}
    
    		public bool PrintMe {
    			get {
    				return _PrintMe;
    			}
    		}
    	}
    }
