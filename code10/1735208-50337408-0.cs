    using System;
	using System.Collections.Generic;
	using System.Linq;
	using Autofac;
	using Autofac.Features.Indexed;
	
	
	public class Program
	{
		private static IContainer _Container;
		
		public static void Main()
		{
			InitDependencyInjection();	
			
			var rd1 = _Container.Resolve<RequiresDependency>(new NamedParameter("letterId", 1));
			rd1.PrintType();
			
			var rd2 = _Container.Resolve<RequiresDependency>(new NamedParameter("letterId", 2));
			rd2.PrintType();
		}
		
		private static void InitDependencyInjection()
		{
			var builder = new ContainerBuilder();
			
			
			var letterTypes = typeof(LetterBase).Assembly.GetTypes()
				.Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(LetterBase)))
				.Where(t => t.GetCustomAttributes(typeof(LetterTypeAttribute), false).Length == 1)
				.ToList();
			
			
			foreach(Type letterType in letterTypes)
			{
				var attribute = letterType.GetCustomAttributes(typeof(LetterTypeAttribute), false)[0] as LetterTypeAttribute;
				
				builder.RegisterType(letterType)
					.Keyed<LetterBase>(attribute.LetterId);
			}
			
			builder.RegisterType<RequiresDependency>();
			
			_Container = builder.Build();
		}
		
	}
	
	public class RequiresDependency
	{
		private readonly LetterBase _letter;
		
		public RequiresDependency(int letterId, IIndex<int, LetterBase> letterFactory)
		{
			_letter = letterFactory[letterId];
		}
		
		public void PrintType()
		{
			Console.WriteLine(_letter.GetType().Name);
		}
	}
	
	public abstract class LetterBase
	{
	}
	
	[LetterType(1)]
	public class LetterA : LetterBase
	{}
	
	[LetterType(2)]
	public class LetterB : LetterBase
	{}
	
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class LetterTypeAttribute : Attribute
	{
		public LetterTypeAttribute(int letterId)
		{
			LetterId = letterId;
		}
		
		public int LetterId { get; private set; }
	}
