    static void Main(string[] args)
    {
        //rootNote = 60(C), note = 60(C) - output 0
        //rootNote = 60(C), note = 61(C#) - output 2
        //rootNote = 60(C), note = 62(D) - output 4
        //rootNote = 60(C), note = 63(D#) - output 5
        //rootNote = 61(C#), note = 60 (C) - output 0
        //rootNote = 61(C#), note = 61 (C#) - output 1
        //rootNote = 61(C#), note = 62 (D) - output 3
        //rootNote = 61(C#), note = 63 (D#) - output 5
    
        Console.WriteLine(getINMajorScale(60, 60));  // 0
        Console.WriteLine(getINMajorScale(61, 60));  // 2
        Console.WriteLine(getINMajorScale(62, 60));  // 4
        Console.WriteLine(getINMajorScale(63, 60));  // 5
        Console.WriteLine(getINMajorScale(60, 61));  // 0
        Console.WriteLine(getINMajorScale(61, 61));  // 1
        Console.WriteLine(getINMajorScale(62, 61));  // 3
        Console.WriteLine(getINMajorScale(63, 61));  // 5
    
        Console.ReadKey();
    }
