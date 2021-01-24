    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using System.Collections.Generic;
    namespace CoreSandbox
    {
	    [DisassemblyDiagnoser(printAsm: true, printSource: false, printPrologAndEpilog: true, printIL: false, recursiveDepth: 1)]
        //[MemoryDiagnoser]
        public class Test
        {
            private List<MyObject> dataWithArray;
	    	private List<MyObjectLight> dataWithoutArray;
            [Params(500_000)]
            public int size;
    		public class MyObject
		    {
	    		public int value = 1;
    			public int[] value1 = new int[80];
		    }
	    	public class MyObjectLight
    		{
		    	public int value = 1;
	    	}
    		static void Main(string[] args)
            {
                var summary = BenchmarkRunner.Run<Test>();
            }
            [GlobalSetup]
            public void Setup()
            {
			    dataWithArray = new List<MyObject>(size);
		    	dataWithoutArray = new List<MyObjectLight>(size);
                for (var i = 0; i < size; i++)
                {
			    	dataWithArray.Add(new MyObject());
		    		dataWithoutArray.Add(new MyObjectLight());
                }
            }
            [Benchmark(Baseline = true)]
            public int WithArray()
            {
                var counter = 0;
                foreach(var obj in dataWithArray)
                {
				    if (obj.value == 1)
			    		counter++;
		    	}
                return counter;
            }
		    [Benchmark]
	    	public int WithoutArray()
    		{
    			var counter = 0;
	    		foreach (var obj in dataWithoutArray)
    			{
    				if (obj.value == 1)
	    				counter++;
    			}
		    	return counter;
	    	}
    	}
    }
