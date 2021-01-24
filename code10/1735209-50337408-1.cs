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
                // Find all types that derice from LetterBase
				.Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(LetterBase)))
                // Make sure they are decorated by attribute
				.Where(t => t.GetCustomAttributes(typeof(LetterTypeAttribute), false).Length == 1)
				.ToList();
			
			//Register with Autofac, Keyed by LetterId
            //This should throw an exception if any are duplicated
            //You may want to consider using an enum instead
            //It's not hard to convert an Int to Enum
			foreach(Type letterType in letterTypes)
			{
                // we already tested the type has the attribute above
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
		
        //Autofac automagically provides a factory that returns type
        //type you need via indexer
		public RequiresDependency(int letterId, IIndex<int, LetterBase> letterFactory)
		{
            //resolve the needed type based on the index value passed in
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
	
    // make sure the classes using this attribute has only a single attribute
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class LetterTypeAttribute : Attribute
	{
		public LetterTypeAttribute(int letterId)
		{
			LetterId = letterId;
		}
		
		public int LetterId { get; private set; }
	}
