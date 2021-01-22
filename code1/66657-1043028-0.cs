	Iterable<Integer> numbers = new Range(1, 100);
	Iterable<Integer> primes = numbers.inject(numbers, new Functions.Injecter<Iterable<Integer>, Integer>()
	{
		public Iterable<Integer> call(Iterable<Integer> numbers, final Integer number) throws Exception
		{
			// We don't test for 1 which is implicit
			if ( number <= 1 )
			{
				return numbers;
			}
			// Only keep in numbers those that do not divide by number
			return numbers.reject(new Functions.Predicate1<Integer>()
			{
				public Boolean call(Integer n) throws Exception
				{
					return n > number && n % number == 0;
				}
			});
		}
	});
