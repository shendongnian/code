    using System;
    namespace ConsoleApplication1
    {
    	internal class Junk
    	{
    		public void Hello()
    		{
    			Console.WriteLine("Hello");
    		}
    	}
    }
    
    using Microsoft.CSharp.RuntimeBinder;
    using System;
    using System.Runtime.CompilerServices;
    namespace ConsoleApplication1
    {
    	internal class Program
    	{
    		[CompilerGenerated]
    		private static class <Main>o__SiteContainer0
    		{
    			public static CallSite<Action<CallSite, object>> <>p__Site1;
    		}
    		private static void Main(string[] args)
    		{
    			Junk a = new Junk();      //NOTE: Compiler converted var to Junk
    			object b = new Junk();    //NOTE: Compiler converted dynamic to object
    			a.Hello();  //Already Junk so just call the method.
                              //NOTE: Runtime binding (late binding) implementation added by compiler.
    			if (Program.<Main>o__SiteContainer0.<>p__Site1 == null)
    			{
    				Program.<Main>o__SiteContainer0.<>p__Site1 = CallSite<Action<CallSite, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Hello", null, typeof(Program), new CSharpArgumentInfo[]
    				{
    					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
    				}));
    			}
    			Program.<Main>o__SiteContainer0.<>p__Site1.Target(Program.<Main>o__SiteContainer0.<>p__Site1, b);
    		}
    	}
    }
