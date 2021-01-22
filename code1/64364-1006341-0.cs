    using System;
    using System.Reflection; 
    
    
    class Foo
    {
    	public string abc;
    }
    class Bar : Foo
    {
    	private int def = 0;
    }
    static class Program
    {
    	static void Main()
    	{
    		object obj = new Bar();
    		object objShouldNotHaveIt = new Foo();
    		object objShouldHaveIt = new Bar();
				string myQuestion = "How-to get a System.Collections.Generic.List<FieldInfo> list which holds all FieldInfo’s of an object of a Type T up to the Object in the class hierarchy in C# ?"; 
    
    		if (Program.SearchFieldByValue(objShouldNotHaveIt, "def", 0))
    			Console.WriteLine(" NOK"); 
    
    		if ( Program.SearchFieldByValue(objShouldHaveIt , "def" , 0 ))
    			Console.WriteLine(" OK ");
				Console.WriteLine("Is a " + myQuestion.Length.ToString() + " chars long string considered as long question ? "); 
      
    
    
    		Console.ReadLine();
    	} //eof main 
    
    
    	public static bool SearchFieldByValue ( object obj , string strFieldName , object objFieldValue ) 
    	{
    	
    		FieldInfo[] fields = obj.GetType().GetFields(
    		BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
    		foreach (FieldInfo field in fields)
    		{
    			object objFieldValueReflected = field.GetValue(obj) ; 
    			Console.WriteLine(field.Name + " = " + field.GetValue(obj));
    			if (objFieldValueReflected != null && objFieldValue.ToString().Equals(objFieldValueReflected.ToString()))
    				return true;
    			else
    				continue; 
    		}
    		return false; 
    
    	} //eof method 
    
    
    
    
    
    
    } //eof class 
