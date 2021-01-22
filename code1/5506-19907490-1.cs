    1. [Broken covariance.][3]
            string[] strings = ...
            object[] objects = strings;
            objects[0] = 1; //compiles, but gives a runtime exception.
    2. [Arrays can give you reference to a struct!][4]. That's unlike anywhere else. A sample: 
            struct Value { public int mutable; }
            var array = new[] { new Value() };	
            array[0].mutable = 1; //<-- compiles !
            //a List<Value>[0].mutable = 1; doesnt compile since editing a copy makes no sense
            print array[0].mutable // 1, expected or unexpected? confusing surely
    3. [Run time implemented methods like `ICollection<T>.Contains` can be different for structs and classes][5]. It's not a big deal, but if you forget to override *non generic `Equals`* correctly for reference types expecting generic collection to look for *generic `Equals`*, you will get incorrect results.
			public class Class : IEquatable<Class>
			{
			    public bool Equals(Class other)
			    {
			    	Console.WriteLine("generic");
			        return true;
			    }
			    public override bool Equals(object obj)
			    {
			    	Console.WriteLine("non generic");
			        return true;
			    } 
			}
			public struct Struct : IEquatable<Struct>
			{
			    public bool Equals(Struct other)
			    {
			    	Console.WriteLine("generic");
			        return true;
			    }
			    public override bool Equals(object obj)
			    {
			    	Console.WriteLine("non generic");
			        return true;
			    } 
			}
            class[].Contains(test); //prints "non generic"
            struct[].Contains(test); //prints "generic"
    4. The `Length` property and `[]` indexer on `T[]` seem to be regular properties that you can access through reflection (which should involve some magic), but when it comes to expression trees you have to spit out the exact same code the compiler does. There are `ArrayLength` and `ArrayIndex` methods to do that separately. One such [question here][6]. Another example:
            Expression<Func<string>> e = () => new[] { "a" }[0];
            //e.Body.NodeType == ExpressionType.ArrayIndex
            Expression<Func<string>> e = () => new List<string>() { "a" }[0];
            //e.Body.NodeType == ExpressionType.Call;
