       1. using System;  
       2. using System.Reflection;  
       3.   
       4. namespace YourNamespace
       5. {  
       6.     public partial class StaticDemo: System.Web.UI.Page  
       7.     {  
       8.         protected void Page_Load(object sender, EventArgs e)  
       9.         {  
      10.             Assembly assemblyInstance = Assembly.GetExecutingAssembly();  
      11.             Type thisClass = assemblyInstance.GetType("YourNamespace.StaticDemo", false, true);  
      12.             MethodInfo m = thisClass.GetMethod("MyMethod");  
      13.             object result = m.Invoke(null, null);  
      14.             string s = result.ToString();  
      15.         }  
      16.   
      17.         public static string MyMethod()  
      18.         {  
      19.             return "Do whatever you want here!!!";  
      20.         }  
      21.   
      22.     }  
      23. }  
