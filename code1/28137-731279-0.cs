    //Again, the cast to a generic type parameter not possible in c#; also, this requires a List<T> as input instead of just an IEnumerable<T>.
    list.ConvertAll<TOutput>( new Converter<TInput,TOuput>( (TInput x) => (TOutput)x ) );
    //This would be nice, except reflection is used, and must be used since c# hides the method name for explicit operators "op_Explicit", making it difficult to obtain a delegate any other way.
    list.ConvertAll<TOutput>(
		(Converter<TInput,TOutput>)Delegate.CreateDelegate(
			typeof(Converter<TInput,TOutput>),
			typeof(TOutput).GetMethod( "op_Explicit", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public )
		)
    );
