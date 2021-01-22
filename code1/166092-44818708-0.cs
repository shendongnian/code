		public (double sum, double average) ComputeSumAndAverage(List<double> list)
        {
           var sum= list.Sum();
            var average = sum/list.Count;
            return (sum, average);
        }
		How to use:
		
			var list=new List<double>{1,2,3};
            var result = ComputeSumAndAverage(list);
            Console.WriteLine($"Sum={result.sum} Average={result.average}");	
