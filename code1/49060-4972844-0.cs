	using System;
	using System.Collections.Generic;
	using System.Linq;
	using visitor.Extension;
	namespace visitor
	{
		namespace Extension
		{
			static class Extension
			{
				public static void RunVisitor(this IThing thing, IThingOperation thingOperation)
				{
					thingOperation.Visit((dynamic)thing);
				}
				public static ITransformedThing GetTransformedThing(this IThing thing, int arg)
				{
					var x = new GetTransformedThing {Arg = arg};
					thing.RunVisitor(x);
					return x.Result;
				}
			}
		}
		interface IThingOperation
		{
			void Visit(IThing iThing);
			void Visit(AThing aThing);
			void Visit(BThing bThing);
			void Visit(CThing cThing);
			void Visit(DThing dThing);
		}
		interface ITransformedThing { }
		class ATransformedThing : ITransformedThing { public ATransformedThing(AThing aThing, int arg) { } }
		class BTransformedThing : ITransformedThing { public BTransformedThing(BThing bThing, int arg) { } }
		class CTransformedThing : ITransformedThing { public CTransformedThing(CThing cThing, int arg) { } }
		class DTransformedThing : ITransformedThing { public DTransformedThing(DThing dThing, int arg) { } }
		class GetTransformedThing : IThingOperation
		{
			public int Arg { get; set; }
			public ITransformedThing Result { get; private set; }
			public void Visit(IThing iThing) { Result = null; }
			public void Visit(AThing aThing) { Result = new ATransformedThing(aThing, Arg); }
			public void Visit(BThing bThing) { Result = new BTransformedThing(bThing, Arg); }
			public void Visit(CThing cThing) { Result = new CTransformedThing(cThing, Arg); }
			public void Visit(DThing dThing) { Result = new DTransformedThing(dThing, Arg); }
		}
		interface IThing {}
		class Thing : IThing {}
		class AThing : Thing {}
		class BThing : Thing {}
		class CThing : Thing {}
		class DThing : Thing {}
		class EThing : Thing { }
		class Program
		{
			static void Main(string[] args)
			{
				var things = new List<IThing> { new AThing(), new BThing(), new CThing(), new DThing(), new EThing() };
				var transformedThings = things.Select(thing => thing.GetTransformedThing(4)).Where(transformedThing => transformedThing != null).ToList();
				foreach (var transformedThing in transformedThings)
				{
					Console.WriteLine(transformedThing.GetType().ToString());
				}
			}
		}
	}
