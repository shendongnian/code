    using System;
    using System.Text.RegularExpressions;
    using System.Diagnostics;
    using System.Threading;
    using System.Text;
    
    static class Program
    {
        public static void Main(string[] args)
        {
        long seed = ConfigProgramForBenchmarking();
        Stopwatch sw = new Stopwatch();
        string warmup = "This is   a Warm  up function for best   benchmark results." + seed;
        string input1 = "Hello World,    how are   you           doing?" + seed;
        string input2 = "It\twas\t \tso    nice  to\t\t see you \tin 1950.  \t" + seed;
        string correctOutput1 = "Hello World, how are you doing?" + seed;
        string correctOutput2 = "It\twas\tso nice to\tsee you in 1950. " + seed;
        string output1,output2;
        //warm-up timer function
        sw.Restart();
        sw.Stop();
        sw.Restart();
        sw.Stop();
        long baseVal = sw.ElapsedTicks;
        // InPlace Replace by Felipe Machado but modified by Ryan for multi-space removal (http://www.codeproject.com/Articles/1014073/Fastest-method-to-remove-all-whitespace-from-Strin)
        output1 = InPlaceCharArraySpaceOnly (warmup);
        sw.Restart();
        output1 = InPlaceCharArraySpaceOnly (input1);
        output2 = InPlaceCharArraySpaceOnly (input2);
        sw.Stop();
        Console.WriteLine("InPlaceCharArraySpaceOnly : " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        // InPlace Replace by Felipe R. Machado and slightly modified by Ryan for multi-space removal (http://www.codeproject.com/Articles/1014073/Fastest-method-to-remove-all-whitespace-from-Strin)
        output1 = InPlaceCharArray(warmup);
        sw.Restart();
        output1 = InPlaceCharArray(input1);
        output2 = InPlaceCharArray(input2);
        sw.Stop();
        Console.WriteLine("InPlaceCharArray: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        //Regex with non-compile Tim Hoolihan (https://stackoverflow.com/a/1279874/2352507)
        string cleanedString = 
        output1 = Regex.Replace(warmup, @"\s+", " ");
        sw.Restart();
        output1 = Regex.Replace(input1, @"\s+", " ");
        output2 = Regex.Replace(input2, @"\s+", " ");
        sw.Stop();
        Console.WriteLine("Regex by Tim Hoolihan: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        //Regex with compile by Jon Skeet (https://stackoverflow.com/a/1280227/2352507)
        output1 = MultipleSpaces.Replace(warmup, " ");
        sw.Restart();
        output1 = MultipleSpaces.Replace(input1, " ");
        output2 = MultipleSpaces.Replace(input2, " ");
        sw.Stop();
        Console.WriteLine("Regex with compile by Jon Skeet: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        //Split And Join by Jon Skeet (https://stackoverflow.com/a/1280227/2352507)
        output1 = SplitAndJoinOnSpace(warmup);
        sw.Restart();
        output1 = SplitAndJoinOnSpace(input1);
        output2 = SplitAndJoinOnSpace(input2);
        sw.Stop();
        Console.WriteLine("Split And Join by Jon Skeet: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        //Regex by Brandon (https://stackoverflow.com/a/1279878/2352507
        output1 = Regex.Replace(warmup, @"\s{2,}", " ");
        sw.Restart();
        output1 = Regex.Replace(input1, @"\s{2,}", " ");
        output2 = Regex.Replace(input2, @"\s{2,}", " ");
        sw.Stop();
        Console.WriteLine("Regex by Brandon: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        //StringBuilder by user214147 (https://stackoverflow.com/a/2156660/2352507
        output1 = user214147(warmup);
        sw.Restart();
        output1 = user214147(input1);
        output2 = user214147(input2);
        sw.Stop();
        Console.WriteLine("StringBuilder by user214147: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        //StringBuilder by fubo (https://stackoverflow.com/a/27502353/2352507
        output1 = fubo(warmup);
        sw.Restart();
        output1 = fubo(input1);
        output2 = fubo(input2);
        sw.Stop();
        Console.WriteLine("StringBuilder by fubo: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
        //StringBuilder by David S 2013 (https://stackoverflow.com/a/16035044/2352507)
        output1 = SingleSpacedTrim(warmup);
        sw.Restart();
        output1 = SingleSpacedTrim(input1);
        output2 = SingleSpacedTrim(input2);
        sw.Stop();
        Console.WriteLine("StringBuilder(SingleSpacedTrim) by David S: " + (sw.ElapsedTicks - baseVal));
        Console.WriteLine("  Trial1:(spaces only) " + (output1 == correctOutput1 ? "PASS " : "FAIL "));
        Console.WriteLine("  Trial2:(spaces+tabs) " + (output2 == correctOutput2 ? "PASS " : "FAIL "));
    }
    // InPlace Replace by Felipe Machado and slightly modified by Ryan for multi-space removal (http://www.codeproject.com/Articles/1014073/Fastest-method-to-remove-all-whitespace-from-Strin)
    static string InPlaceCharArray(string str)
    {
        var len = str.Length;
        var src = str.ToCharArray();
        int dstIdx = 0;
        bool lastWasWS = false;
        for (int i = 0; i < len; i++)
        {
            var ch = src[i];
            if (src[i] == '\u0020')
            {
                if (lastWasWS == false)
                {
                    src[dstIdx++] = ch;
                    lastWasWS = true;
                }
            }
            else
            { 
                lastWasWS = false;
                src[dstIdx++] = ch;
            }
        }
        return new string(src, 0, dstIdx);
    }
    // InPlace Replace by Felipe R. Machado but modified by Ryan for multi-space removal (http://www.codeproject.com/Articles/1014073/Fastest-method-to-remove-all-whitespace-from-Strin)
    static string InPlaceCharArraySpaceOnly (string str)
    {
        var len = str.Length;
        var src = str.ToCharArray();
        int dstIdx = 0;
        bool lastWasWS = false; //Added line
        for (int i = 0; i < len; i++)
        {
            var ch = src[i];
            switch (ch)
            {
                case '\u0020': //SPACE
                case '\u00A0': //NO-BREAK SPACE
                case '\u1680': //OGHAM SPACE MARK
                case '\u2000': // EN QUAD
                case '\u2001': //EM QUAD
                case '\u2002': //EN SPACE
                case '\u2003': //EM SPACE
                case '\u2004': //THREE-PER-EM SPACE
                case '\u2005': //FOUR-PER-EM SPACE
                case '\u2006': //SIX-PER-EM SPACE
                case '\u2007': //FIGURE SPACE
                case '\u2008': //PUNCTUATION SPACE
                case '\u2009': //THIN SPACE
                case '\u200A': //HAIR SPACE
                case '\u202F': //NARROW NO-BREAK SPACE
                case '\u205F': //MEDIUM MATHEMATICAL SPACE
                case '\u3000': //IDEOGRAPHIC SPACE
                case '\u2028': //LINE SEPARATOR
                case '\u2029': //PARAGRAPH SEPARATOR
                case '\u0009': //[ASCII Tab]
                case '\u000A': //[ASCII Line Feed]
                case '\u000B': //[ASCII Vertical Tab]
                case '\u000C': //[ASCII Form Feed]
                case '\u000D': //[ASCII Carriage Return]
                case '\u0085': //NEXT LINE
                    if (lastWasWS == false) //Added line
                    {
                        src[dstIdx++] = ch; //Added line
                        lastWasWS = true; //Added line
                    }
                continue;
                default:
                    lastWasWS = false; //Added line 
                    src[dstIdx++] = ch;
                    break;
            }
        }
        return new string(src, 0, dstIdx);
    }
    static readonly Regex MultipleSpaces =
        new Regex(@" {2,}", RegexOptions.Compiled);
    //Split And Join by Jon Skeet (https://stackoverflow.com/a/1280227/2352507)
    static string SplitAndJoinOnSpace(string input)
    {
        string[] split = input.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
        return string.Join(" ", split);
    }
    //StringBuilder by user214147 (https://stackoverflow.com/a/2156660/2352507
    public static string user214147(string S)
    {
        string s = S.Trim();
        bool iswhite = false;
        int iwhite;
        int sLength = s.Length;
        StringBuilder sb = new StringBuilder(sLength);
        foreach (char c in s.ToCharArray())
        {
            if (Char.IsWhiteSpace(c))
            {
                if (iswhite)
                {
                    //Continuing whitespace ignore it.
                    continue;
                }
                else
                {
                    //New WhiteSpace
                    //Replace whitespace with a single space.
                    sb.Append(" ");
                    //Set iswhite to True and any following whitespace will be ignored
                    iswhite = true;
                }
            }
            else
            {
                sb.Append(c.ToString());
                //reset iswhitespace to false
                iswhite = false;
            }
        }
        return sb.ToString();
    }
    //StringBuilder by fubo (https://stackoverflow.com/a/27502353/2352507
    public static string fubo(this string Value)
    {
        StringBuilder sbOut = new StringBuilder();
        if (!string.IsNullOrEmpty(Value))
        {
            bool IsWhiteSpace = false;
            for (int i = 0; i < Value.Length; i++)
            {
                if (char.IsWhiteSpace(Value[i])) //Comparison with WhiteSpace
                {
                    if (!IsWhiteSpace) //Comparison with previous Char
                    {
                        sbOut.Append(Value[i]);
                        IsWhiteSpace = true;
                    }
                }
                else
                {
                    IsWhiteSpace = false;
                    sbOut.Append(Value[i]);
                }
            }
        }
        return sbOut.ToString();
    }
    
    //David S. 2013 (https://stackoverflow.com/a/16035044/2352507)
    public static String SingleSpacedTrim(String inString)
    {
        StringBuilder sb = new StringBuilder();
        Boolean inBlanks = false;
        foreach (Char c in inString)
        {
            switch (c)
            {
                case '\r':
                case '\n':
                case '\t':
                case ' ':
                    if (!inBlanks)
                    {
                        inBlanks = true;
                        sb.Append(' ');
                    }
                    continue;
                default:
                    inBlanks = false;
                    sb.Append(c);
                    break;
            }
        }
        return sb.ToString().Trim();
    }
    /// <summary>
    /// We want to run this item with max priory to lower the odds of
    /// the OS from doing program context switches in the middle of our code. 
    /// source:https://stackoverflow.com/a/16157458 
    /// </summary>
    /// <returns>random seed</returns>
    private static long ConfigProgramForBenchmarking()
    {
        //prevent the JIT Compiler from optimizing Fkt calls away
        long seed = Environment.TickCount;
        //use the second Core/Processor for the test
        Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
        //prevent "Normal" Processes from interrupting Threads
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
        //prevent "Normal" Threads from interrupting this thread
        Thread.CurrentThread.Priority = ThreadPriority.Highest;
        return seed;
    }
