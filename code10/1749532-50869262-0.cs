    string strDLL = @"Dll Path";
    string txtUserName = "test user name";
    
    Assembly assembly = Assembly.LoadFrom(strDLL);
    Type type = assembly.GetType("TestLib.MyClass");
    object objplugin = Activator.CreateInstance(type);
    var objUserIdProp = type.GetProperty("UserID");
    objUserIdProp.SetValue(objplugin, txtUserName);
    var methodInfo = type.GetMethod("TestMethod");
    methodInfo.Invoke(objplugin, null);
    namespace TestLib
    {
        public class MyClass
        {
    		public string UserID { get; set; }
    
    		public void TestMethod()
    		{
    			Console.WriteLine("TestMethod work");
    		}
    	}
    }
