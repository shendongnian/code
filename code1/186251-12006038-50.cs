	public class test : ICustomMemberProvider 
	{
		  IEnumerable<string> ICustomMemberProvider.GetNames() {
			return new List<string>{"Hint", "constMember1", "constMember2", "myprop"};
		  }
		  
		  IEnumerable<Type> ICustomMemberProvider.GetTypes() 
		  {
			return new List<Type>{typeof(string), typeof(string[]), 
			    typeof(string), typeof(string)};
		  }
		  
		  IEnumerable<object> ICustomMemberProvider.GetValues() 
		  {
			return new List<object>{
			"This class contains custom properties for .Dump()", 
			new string[]{"A", "B", "C"}, "blabla", abc};
		  }
		  public string abc = "Hello1"; // abc is shown as "myprop"
		  public string xyz = "Hello2"; // xyz is entirely hidden
	}
