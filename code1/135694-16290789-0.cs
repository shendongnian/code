	/// <summary>
	/// Fixes an argument of an action delegate, creating a closure that combines the 
	/// delegate and the argument value. 
	/// </summary>
	/// <returns>An action delegate which takes only one argument.</returns>
	public static Action<TIn1> FixActionArgument<TIn1, TIn2>(Action<TIn1, TIn2> action, 
		TIn2 argumentValue)
	{
		return in1 => action(in1, argumentValue);
	}
