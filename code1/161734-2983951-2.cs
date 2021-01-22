    using System;
    using System.Collections.Generic;
    using Castle.Core;
    using Castle.Core.Interceptor;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using NUnit.Framework;
    
    [TestFixture]
    public class LoggingMethodInvocationsTests
    {
    	[Test]
    	public void CanLogInvocations()
    	{
    		var container = new WindsorContainer();
    		container.Register(Component.For<LoggingInterceptor>().LifeStyle.Singleton);
    		// log all calls to the interface
    		container.Register(Component.For<IA>().ImplementedBy<A>().Interceptors(typeof (LoggingInterceptor)));
    
    		var a = container.Resolve<IA>();
    		a.AMethod(3.1415926535); // to interface
    		Console.WriteLine("End of test");
    	}
    }
    
    public class LoggingInterceptor : IInterceptor, IOnBehalfAware
    {
    	private string _entityName;
    
    	public void Intercept(IInvocation invocation)
    	{
    		var largs = new List<string>(invocation.Arguments.Length);
    
    		for (int i = 0; i < invocation.Arguments.Length; i++)
    			largs.Add(invocation.Arguments[i].ToString());
    
    		var a = largs.Count == 0 ? "[no arguments]" : string.Join(", ", largs.ToArray());
    		var method = invocation.Method == null ? "[on interface target]" : invocation.Method.Name;
    
    		Console.WriteLine(string.Format("{0}.{1} called with arguments {2}", _entityName, method, a));
    
    		invocation.Proceed();
    
    		Console.WriteLine(string.Format("After invocation. Return value {0}", invocation.ReturnValue));
    	}
    
    	public void SetInterceptedComponentModel(ComponentModel target)
    	{
    		if (target != null)
    			_entityName = target.Implementation.FullName;
    	}
    }
    
    public class A : IA
    {
    	public double AMethod(double a)
    	{
    		Console.WriteLine("A method impl");
    		return a*2;
    	}
    
    	public void SecondMethod(double a)
    	{
    		Console.WriteLine(string.Format("Impl: SecondMethod called with {0}", a));
    	}
    }
    
    public interface IA
    {
    	double AMethod(double a);
    }
