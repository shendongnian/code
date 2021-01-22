    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace System.Collections.Generic //purposely in same namespace as List<T>,IEnumerable<T>, so extension methods are available with them
    {
    	public static class Enumerable
    	{
    		public static List<TOutput> ConvertAll<TInput,TOutput>( this IEnumerable<TInput> input ) {
    			return BuildConvertedList<TInput,TOutput>( input, GetConverterDelegate<TInput,TOutput>() );
    		}
    
    		public static IEnumerable<TOutput> ConvertAll<TInput,TOutput>( this IEnumerable<TInput> input, bool lazy ) {
    			if (lazy) return new LazyConverter<TInput,TOutput>( input, GetConverterDelegate<TInput,TOutput>() );
    			return BuildConvertedList<TInput,TOutput>( input, GetConverterDelegate<TInput,TOutput>() );
    		}
    
    		public static List<TOutput> ConvertAll<TInput,TOutput>( this IEnumerable<TInput> input, Converter<TInput, TOutput> converter ) {
    			return BuildConvertedList<TInput,TOutput>( input, converter );
    		}
    
    		public static List<TOutput> ConvertAll<TInput, TOutput>( this List<TInput> input ) {
    			Converter<TInput, TOutput> converter = GetConverterDelegate<TInput,TOutput>();
    			return input.ConvertAll<TOutput>( converter );
    		}
    
    		public static IEnumerable<TOutput> ConvertAll<TInput, TOutput>( this List<TInput> input, Converter<TInput, TOutput> converter, bool lazy ) {
    			if (lazy) return new LazyConverter<TInput, TOutput>( input, converter );
    			return input.ConvertAll<TOutput>( converter );
    		}
    
    		public static List<TOutput> ConvertAll<TInput, TOutput>( this List<TInput> input, Converter<TInput, TOutput> converter ) {
    			return input.ConvertAll<TOutput>( converter );
    		}
    
    		//Used to manually build converted list when input is IEnumerable, since it doesn't have the ConvertAll method like the List does
    		private static List<TOutput> BuildConvertedList<TInput,TOutput>( IEnumerable<TInput> input, Converter<TInput, TOutput> converter ){
    			List<TOutput> output = new List<TOutput>();
    			foreach (TInput input_item in input)
    				output.Add( converter( input_item ) );
    			return output;
    		}
    
    		private sealed class LazyConverter<TInput, TOutput>: IEnumerable<TOutput>, IEnumerator<TOutput>
    		{
    			private readonly IEnumerable<TInput> input;
    			private readonly Converter<TInput, TOutput> converter;
    			private readonly IEnumerator<TInput> input_enumerator;
    
    			public LazyConverter( IEnumerable<TInput> input, Converter<TInput, TOutput> converter )
    			{
    				this.input = input;
    				this.converter = converter;
    				this.input_enumerator = input.GetEnumerator();
    			}
    
    			public IEnumerator<TOutput> GetEnumerator() {return this;} //IEnumerable<TOutput> Member
    			IEnumerator IEnumerable.GetEnumerator() {return this;} //IEnumerable Member
    			public void Dispose() {input_enumerator.Dispose();} //IDisposable Member
    			public TOutput Current {get	{return converter.Invoke( input_enumerator.Current );}} //IEnumerator<TOutput> Member
    			object IEnumerator.Current {get {return Current;}} //IEnumerator Member
    			public bool MoveNext() {return input_enumerator.MoveNext();} //IEnumerator Member
    			public void Reset() {input_enumerator.Reset();} //IEnumerator Member
    		}
    
    		private sealed class TypeConversionPair: IEquatable<TypeConversionPair>
    		{
    			public readonly Type source_type;
    			public readonly Type target_type;
    			private readonly int hashcode;
    
    			public TypeConversionPair( Type source_type, Type target_type ) {
    				this.source_type = source_type;
    				this.target_type = target_type;
    				//precalc/store hash, since object is immutable; add one to source hash so reversing the source and target still produces unique hash
    				hashcode = (source_type.GetHashCode() + 1) ^ target_type.GetHashCode();
    			}
    
    			public static bool operator ==( TypeConversionPair x, TypeConversionPair y ) {
    				if ((object)x != null) return x.Equals( y );
    				if ((object)y != null) return y.Equals( x );
    				return true; //x and y are both null, cast to object above ensures reference equality comparison
    			}
    
    			public static bool operator !=( TypeConversionPair x, TypeConversionPair y ) {
    				if ((object)x != null) return !x.Equals( y );
    				if ((object)y != null) return !y.Equals( x );
    				return false; //x and y are both null, cast to object above ensures reference equality comparison
    			}
    
    			//TypeConversionPairs are equal when their source and target types are equal
    			public bool Equals( TypeConversionPair other ) {
    				if ((object)other == null) return false; //cast to object ensures reference equality comparison
    				return source_type == other.source_type && target_type == other.target_type;
    			}
    			
    			public override bool Equals( object obj ) {
    				TypeConversionPair other = obj as TypeConversionPair;
    				if ((object)other != null) return Equals( other ); //call IEqualityComparer<TypeConversionPair> implementation if obj type is TypeConversionPair
    				return false; //obj is null or is not of type TypeConversionPair; Equals shall not throw errors!
    			}
    
    			public override int GetHashCode() {return hashcode;} //assigned in constructor; object is immutable
    		}
    
    		private static readonly Dictionary<TypeConversionPair,Delegate> conversion_op_cache = new Dictionary<TypeConversionPair,Delegate>();
    
    		//Uses reflection to find and create a Converter<TInput, TOutput> delegate for the given types.
    		//Once a delegate is obtained, it is cached, so further requests for the delegate do not use reflection*
    		//(*the typeof operator is used twice to look up the type pairs in the cache)
    		public static Converter<TInput, TOutput> GetConverterDelegate<TInput, TOutput>()
    		{
    			Delegate converter;
    			TypeConversionPair type_pair = new TypeConversionPair( typeof(TInput), typeof(TOutput) );
    			
    			//Attempt to quickly find a cached conversion delegate.
    			if (conversion_op_cache.TryGetValue( type_pair, out converter ))
    				return (Converter<TInput, TOutput>)converter;
    
    			//Get potential conversion operators (target-type methods are ordered first)
    			MethodInfo[][] conversion_op_sets = new MethodInfo[2][] {
    				type_pair.target_type.GetMethods( BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy ),
    				type_pair.source_type.GetMethods( BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy )
    			};
    
    			//Find appropriate conversion operator,
    			//favoring operators on target type in case functionally equivalent operators exist,
    			//since the target type's conversion operator may have access to an appropriate constructor
    			//or a common instance cache (i.e. immutable objects may be cached and reused).
    			for (int s = 0; s < conversion_op_sets.Length; s++) {
    				MethodInfo[] conversion_ops = conversion_op_sets[s];
    				for (int m = 0; m < conversion_ops.Length; m++)
    				{
    					MethodInfo mi = conversion_ops[m];
    					if ((mi.Name == "op_Explicit" || mi.Name == "op_Implicit") && 
    						mi.ReturnType == type_pair.target_type &&
    						mi.GetParameters()[0].ParameterType.IsAssignableFrom( type_pair.source_type )) //Assuming op_Explicit and op_Implicit always have exactly one parameter.
    					{
    						converter = Delegate.CreateDelegate( typeof(Converter<TInput, TOutput>), mi );
    						conversion_op_cache.Add( type_pair, converter ); //Cache the conversion operator reference for future use.
    						return (Converter<TInput, TOutput>)converter;
    					}
    				}
    			}
    			return (TInput x) => ((TOutput)Convert.ChangeType( x, typeof(TOutput) )); //this works well in the absence of conversion operators for types that implement IConvertible
    			//throw new InvalidCastException( "Could not find conversion operator to convert " + type_pair.source_type.FullName + " to " + type_pair.target_type.FullName + "." );
    		}
    	}
    }
