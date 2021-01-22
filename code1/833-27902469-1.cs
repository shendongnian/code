    const int iterations=1000000;
    var keyprefix= this.GetType().FullName;
    var maxkeylength=keyprefix + 1 + 1+ Math.Log10(iterations);
    Console.WriteLine("KeyPrefix \"{0}\", Max Key Length {1}",keyprefix, maxkeylength);
    
    var concatkeys= new string[iterations];
    var stringbuilderkeys= new string[iterations];
    var cachedsbkeys= new string[iterations];
    var formatkeys= new string[iterations];
    
    var stopwatch= new System.Diagnostics.Stopwatch();
    Console.WriteLine("Concatenation:");
    stopwatch.Start();
    for(int i=0; i<iterations; i++){
    	var key1= keyprefix+":" + i.ToString();
    	concatkeys[i]=key1;
    }
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
    
    Console.WriteLine("New stringBuilder for each key:");
    stopwatch.Restart();
    for(int i=0; i<iterations; i++){
    	var key2= new StringBuilder(keyprefix).Append(":").Append(i.ToString()).ToString();
    	stringbuilderkeys[i]= key2;
    }
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
    
    Console.WriteLine("Cached StringBuilder:");
    var cachedSB= new StringBuilder(maxkeylength);
    stopwatch.Restart();
    for(int i=0; i<iterations; i++){
    	var key2b= cachedSB.Clear().Append(keyprefix).Append(":").Append(i.ToString()).ToString();
    	cachedsbkeys[i]= key2b;
    }
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
    
    Console.WriteLine("string.Format");
    stopwatch.Restart();
    for(int i=0; i<iterations; i++){
    	var key3= string.Format("{0}:{1}", keyprefix,i.ToString());
    	formatkeys[i]= key3;
    }
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
    
    var referToTheComputedValuesSoCompilerCantOptimiseTheLoopsAway= concatkeys.Union(stringbuilderkeys).Union(cachedsbkeys).Union(formatkeys).LastOrDefault(x=>x[1]=='-');
    Console.WriteLine(referToTheComputedValuesSoCompilerCantOptimiseTheLoopsAway);
