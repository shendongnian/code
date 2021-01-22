    private class SearchBound
    {
        public string ArrayName { get; set; }
        public int SubArrayLength { get; set; }
        public string StartBound { get; set; }
        public int StartOffset { get; set; }
        public string EndBound { get; set; }
    }
    
    public static void Main(string[] args)
    {
        //
        // NOTE: I used FireFox to determine the encoding that was used.
        // 
    
        List<string> lines = new List<string>();
    
        // Step 1 - Download the file and dump all the lines of the file to the list.
        var request = WebRequest.Create("http://skema.ku.dk/life1011/js/filter.js");
        using (var response = request.GetResponse())
        using(var stream = response.GetResponseStream())
        using(var reader = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
        {
            string line = null;
    
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line.Trim());
            }
    
            Console.WriteLine("Download Complete.");
    
        }
    
        var deptArrayBounds = new SearchBound
        {
            ArrayName = "deptarray",                    // The name of the JS array.
            SubArrayLength = 2,                         // In the JS, the sub array is defined as "new Array(X)" and should always be X+1 here.
            StartBound = "deptarray[i] = new Array(1);",// The line that should *start* searching for the array values.
            StartOffset = 1,                            // The StartBound + some number line to start searching the array values.
                                                        // For example: the next line might be a '}' so we'd want to skip that line.
            EndBound = "deptarray.sort();"              // The line to stop searching.
        };
    
        var zoneArrayBounds = new SearchBound
        {
            ArrayName = "zonearray",
            SubArrayLength = 2,
            StartBound = "zonearray[i] = new Array(1);",
            StartOffset = 1,
            EndBound = "zonearray.sort();"
        };
    
        var staffArrayBounds = new SearchBound
        {
            ArrayName = "staffarray",
            SubArrayLength = 3,
            StartBound = "staffarray[i] = new Array(2);",
            StartOffset = 1,
            EndBound = "staffarray.sort();"
        };
    
        List<string[]> deptArray = GetArrayValues(lines, deptArrayBounds);
        List<string[]> zoneArray = GetArrayValues(lines, zoneArrayBounds);
        List<string[]> staffArray = GetArrayValues(lines, staffArrayBounds);
        // ... and so on ...
    
        // You can then use deptArray, zoneArray etc where you want...
    
        Console.WriteLine("Depts: " + deptArray.Count);
        Console.WriteLine("Zones: " + zoneArray.Count);
        Console.WriteLine("Staff: " + staffArray.Count);
        Console.ReadKey();
                
    }
    
    private static List<string[]> GetArrayValues(List<string> lines, SearchBound bound)
    {
        List<string[]> values = new List<string[]>();
    
        // Get the enumerator for the lines.
        var enumerator = lines.GetEnumerator();
    
        string line = null;
    
        // Step 1 - Find the starting bound line.
        while (enumerator.MoveNext() && (line = enumerator.Current) != bound.StartBound)
        {
            // Continue looping until we've found the start bound.
        }
    
        // Step 2 - Skip to the right offset (maybe skip a line that has a '}' ).
        for (int i = 0; i <= bound.StartOffset; i++)
        {
            enumerator.MoveNext();
        }
    
        // Step 3 - Read each line of the array.
        while ((line = enumerator.Current) != bound.EndBound)
        {
    
            string[] subArray = new string[bound.SubArrayLength];
    
            // Read each sub-array value.
            for (int i = 0; i < bound.SubArrayLength; i++)
            {
    
                // Matches everything that is between an equal sign then the value 
                // wrapped in quotes ending with a semi-colon.
                var m = Regex.Matches(line, "^(.* = \")(.*)(\";)$");
    
                // Get the matched value.
                subArray[i] = m[0].Groups[2].Value;
    
                // Move to the next sub-item if not the last sub-item.
                if (i < bound.SubArrayLength - 1)
                {
                    enumerator.MoveNext();
                    line = enumerator.Current;
                }
            }
    
            // Add the sub-array to the list of values.
            values.Add(subArray);
    
            // Move to the next line.
            if (!enumerator.MoveNext())
            {
                break;
            }
        }
    
        return values;
    }
