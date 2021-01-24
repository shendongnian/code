    public static SortedDictionary<char, ulong> Count(string stringToCount)
    {
       var characterCount = new SortedDictionary<char, ulong>();
    
       foreach (var character in stringToCount)
          if (!characterCount.ContainsKey(character))       
             characterCount.Add(character, 1);
          else
             characterCount[character]++; //
               
       return characterCount;
    }
    
    static void Main(string[] args)
    {
    
       var filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);  
       var inputFileName = Path.Combine(filePath, args[0]);
       var outputFileName = Path.Combine(filePath, args[2]);
       // read data, count chars
       var count = Count(File.ReadAllText(inputFileName)); 
   
       // create output
       var outPut = count.Select(x => $"{x.Key}\t{x.Value}");
       // write it
       File.WriteAllLines(outputFileName, outPut);
    
    }
