    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            public static string ReverseUsingArrayClass(string text)
            {
                char[] chars = text.ToCharArray();
                Array.Reverse(chars);
                return new string(chars);
            }
            public static string ReverseUsingCharacterBuffer(string text)
            {
                char[] charArray = new char[text.Length];
                int inputStrLength = text.Length - 1;
                for (int idx = 0; idx <= inputStrLength; idx++) 
                {
                    charArray[idx] = text[inputStrLength - idx];                
                }
                return new string(charArray);
            }
            public static string ReverseUsingStringBuilder(string text)
            {
                if (string.IsNullOrEmpty(text))
                {
                    return text;
                }
                StringBuilder builder = new StringBuilder(text.Length);
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    builder.Append(text[i]);
                }
                return builder.ToString();
            }
            private static string ReverseUsingStack(string input)
            {
                Stack<char> resultStack = new Stack<char>();
                foreach (char c in input)
                {
                    resultStack.Push(c);
                }
                StringBuilder sb = new StringBuilder();
                while (resultStack.Count > 0)
                {
                    sb.Append(resultStack.Pop());
                }
                return sb.ToString();
            }
            public static string ReverseUsingXOR(string text)
            {
                char[] charArray = text.ToCharArray();
                int length = text.Length - 1;
                for (int i = 0; i < length; i++, length--)
                {
                    charArray[i] ^= charArray[length];
                    charArray[length] ^= charArray[i];
                    charArray[i] ^= charArray[length];
                }
                return new string(charArray);
            }
            static void Main(string[] args)
            {
                string testString = string.Join(";", new string[] {
                    new string('a', 100), 
                    new string('b', 101), 
                    new string('c', 102), 
                    new string('d', 103),                                                                   
                });
                int cycleCount = 100000;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (int i = 0; i < cycleCount; i++) 
                {
                    ReverseUsingCharacterBuffer(testString);
                }
                stopwatch.Stop();
                Console.WriteLine("ReverseUsingCharacterBuffer: " + stopwatch.ElapsedMilliseconds + "ms");
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < cycleCount; i++) 
                {
                    ReverseUsingArrayClass(testString);
                }
                stopwatch.Stop();
                Console.WriteLine("ReverseUsingArrayClass: " + stopwatch.ElapsedMilliseconds + "ms");
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < cycleCount; i++) 
                {
                    ReverseUsingStringBuilder(testString);
                }
                stopwatch.Stop();
                Console.WriteLine("ReverseUsingStringBuilder: " + stopwatch.ElapsedMilliseconds + "ms");
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < cycleCount; i++) 
                {
                    ReverseUsingStack(testString);
                }
                stopwatch.Stop();
                Console.WriteLine("ReverseUsingStack: " + stopwatch.ElapsedMilliseconds + "ms");
                stopwatch.Reset();
                stopwatch.Start();
                for (int i = 0; i < cycleCount; i++) 
                {
                    ReverseUsingXOR(testString);
                }
                stopwatch.Stop();
                Console.WriteLine("ReverseUsingXOR: " + stopwatch.ElapsedMilliseconds + "ms");            
            }
        }
    }
