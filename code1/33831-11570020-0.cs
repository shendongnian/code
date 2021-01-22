	interface IClonable<T>
	{
		T Clone();
	}
	class Dog : IClonable<JackRabbit>
	{
		//not what you would expect, but possible
		JackRabbit Clone()
		{
			return new JackRabbit();
		}
	}
