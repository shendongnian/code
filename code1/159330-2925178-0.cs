            class Survey
    		{
    			public int P1 { get; set; }
    		}
    
    		class MyObject
    		{
    			readonly List<Survey> _listofSurveys = new List<Survey> { new Survey { P1 = 10 }, new Survey { P1 = 20 } };
    
    
    			public int GetIntAverage(string propertyName)
    			{
    				 var type = typeof(Survey);
    				var property = type.GetProperty(propertyName);
    				return (int)_listofSurveys.Select(x => (int) property.GetValue(x,null)).Average();
    
    			}
    		}
    		static void Main(string[] args)
    		{
    			var myObject = new MyObject();
    			Console.WriteLine(myObject.GetIntAverage("P1"));
    			Console.ReadKey();
    		}
