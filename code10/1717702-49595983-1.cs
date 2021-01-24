	class MainClass
	{
		public static void Main(string[] args)
		{
			ContainerBuilder builder = new ContainerBuilder();
			builder.RegisterType<Interceptor>();
			builder.RegisterType<Dependency>().As<IDependency>();
			builder.RegisterType<Final>().As<IFinal>();
			builder.Register<IFinal>((c, p) =>
			{
				IDependency dependency = c.Resolve<IDependency>();
				int runtimeArgument = p.Named<int>("runtimeArgument");
				return new Final(dependency, runtimeArgument);
			}).As<IFinal>()
	       .EnableInterfaceInterceptors()
	       .InterceptedBy(typeof(Interceptor));
			builder.Register<Factory>((c,p)=>{
				Factory.FactoryMethod finalObjectFactoryMethod = c.Resolve<Factory.FactoryMethod>();
				return new Factory(finalObjectFactoryMethod);
			}).As<IFactory>()
	       .EnableInterfaceInterceptors()
	       .InterceptedBy(typeof(Interceptor));
			IContainer container = builder.Build();
			IFactory factory = container.Resolve<IFactory>();
			IFinal final = factory.GetFinalObject(42);
			final.Test();
		}
	}
	public interface IDependency{}
	public class Dependency: IDependency{}
	public interface IFinal
	{
		void Test();
	}
	public class Final: IFinal
	{
		public Final(IDependency dependency, int runtimeArgument){}
		public void Test(){}
	}
	public interface IFactory
	{
		IFinal GetFinalObject(int runtimeArgument);
	}
	public class Factory: IFactory
	{
		public delegate IFinal FactoryMethod(int runtimeArgument);
		readonly FactoryMethod _finalObjectFactoryMethod;
		public Factory(FactoryMethod finalObjectFactoryMethod)
		{
			_finalObjectFactoryMethod = finalObjectFactoryMethod;
		}
		public IFinal GetFinalObject(int runtimeArgument)
		{
			return _finalObjectFactoryMethod(runtimeArgument);
		}
	}
	public class Interceptor : IInterceptor
	{
		public void Intercept(IInvocation invocation)
		{
			Console.WriteLine($"call {invocation.Method.Name}");
			invocation.Proceed();
			Console.WriteLine($"return from {invocation.Method.Name}");
		}
	}
