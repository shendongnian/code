    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;
    
    class Benchmark
    {
        const string TestData = "ThisIsAUpperCaseString";
        const string ValidResult = "This Is A Upper Case String";
        const int Iterations = 1000000;
        
        static void Main(string[] args)
        {
            Test(BenchmarkOverhead);
            Test(MakeNiceString);
            Test(ImprovedMakeNiceString);
            Test(RefactoredMakeNiceString);
            Test(MakeNiceStringWithStringIndexer);
            Test(MakeNiceStringWithForeach);
            Test(MakeNiceStringWithForeachAndLinqSkip);
            Test(MakeNiceStringWithForeachAndCustomSkip);
            Test(SplitCamelCase);
            Test(SplitCamelCaseCachedRegex);
            Test(SplitCamelCaseCompiledRegex);        
        }
        
        static void Test(Func<string,string> function)
        {
            Console.Write("{0}... ", function.Method.Name);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i=0; i < Iterations; i++)
            {
                string result = function(TestData);
                if (result.Length != ValidResult.Length)
                {
                    throw new Exception("Bad result: " + result);
                }
            }
            sw.Stop();
            Console.WriteLine(" {0}ms", sw.ElapsedMilliseconds);
            GC.Collect();
        }
        
        private static string BenchmarkOverhead(string str)
        {
            return ValidResult;
        }
        
        private static string MakeNiceString(string str)
        {
            char[] ca = str.ToCharArray();
            string result = null;
            int i = 0;
            result += System.Convert.ToString(ca[0]);
            for (i = 1; i <= ca.Length - 1; i++)
            {
                if (!(char.IsLower(ca[i])))
                {
                    result += " ";
                }
                result += System.Convert.ToString(ca[i]);
            }
            return result;
        }
        
        private static string ImprovedMakeNiceString(string str)
        { //Removed Convert.ToString()
            char[] ca = str.ToCharArray();
            string result = null;
            int i = 0;
            result += ca[0];
            for (i = 1; i <= ca.Length - 1; i++)
            {
                if (!(char.IsLower(ca[i])))
                {
                    result += " ";
                }
                result += ca[i];
            }
            return result;
        }
    
        private static string RefactoredMakeNiceString(string str)
        {
            char[] ca = str.ToCharArray();
            StringBuilder sb = new StringBuilder((str.Length * 5 / 4));
            int i = 0;
            sb.Append(ca[0]);
            for (i = 1; i <= ca.Length - 1; i++)
            {
                if (!(char.IsLower(ca[i])))
                {
                    sb.Append(" ");
                }
                sb.Append(ca[i]);
            }
            return sb.ToString();
        }
        
        private static string MakeNiceStringWithStringIndexer(string str)
        {
            StringBuilder sb = new StringBuilder((str.Length * 5 / 4));
            sb.Append(str[0]);
            for (int i = 1; i < str.Length; i++)
            {
                char c = str[i];
                if (!(char.IsLower(c)))
                {
                    sb.Append(" ");
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
    
        private static string MakeNiceStringWithForeach(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length * 5 / 4);
            bool first = true;      
            foreach (char c in str)
            {
                if (!first && char.IsUpper(c))
                {
                    sb.Append(" ");
                }
                sb.Append(c);
                first = false;
            }
            return sb.ToString();
        }
    
        private static string MakeNiceStringWithForeachAndLinqSkip(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length * 5 / 4);
            sb.Append(str[0]);
            foreach (char c in str.Skip(1))
            {
                if (char.IsUpper(c))
                {
                    sb.Append(" ");
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
    
        private static string MakeNiceStringWithForeachAndCustomSkip(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length * 5 / 4);
            sb.Append(str[0]);
            foreach (char c in new SkipEnumerable<char>(str, 1))
            {
                if (char.IsUpper(c))
                {
                    sb.Append(" ");
                }
                sb.Append(c);
            }
            return sb.ToString();
        }
    
        private static string SplitCamelCase(string str)
        {
            string[] temp = Regex.Split(str, @"(?<!^)(?=[A-Z])");
            string result = String.Join(" ", temp);
            return result;
        }
    
        private static readonly Regex CachedRegex = new Regex("(?<!^)(?=[A-Z])");    
        private static string SplitCamelCaseCachedRegex(string str)
        {
            string[] temp = CachedRegex.Split(str);
            string result = String.Join(" ", temp);
            return result;
        }
        
        private static readonly Regex CompiledRegex =
            new Regex("(?<!^)(?=[A-Z])", RegexOptions.Compiled);    
        private static string SplitCamelCaseCompiledRegex(string str)
        {
            string[] temp = CompiledRegex.Split(str);
            string result = String.Join(" ", temp);
            return result;
        }
        
        private class SkipEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerable<T> original;
            private readonly int skip;
                
            public SkipEnumerable(IEnumerable<T> original, int skip)
            {
                this.original = original;
                this.skip = skip;
            }
            
            public IEnumerator<T> GetEnumerator()
            {
                IEnumerator<T> ret = original.GetEnumerator();
                for (int i=0; i < skip; i++)
                {
                    ret.MoveNext();
                }
                return ret;
            }
            
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
