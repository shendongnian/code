    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using System;
    
    static class P
    {
        static void Main()
        {
            var summary = BenchmarkRunner.Run<MyTests>();
            System.Console.WriteLine(summary);
        }
    
    }
    public class MyTests
    {
        const string expression = "14 + 2 * 32 / 60 + 43 - 7 + 3 - 1 + 0 * 7 + 87 - 32 / 34";
        [Benchmark]
        public int Original() => EvalOriginal.Calc(expression);
        [Benchmark]
        public int NoSubStrings() => EvalNoSubStrings.Evaluate(expression);
        [Benchmark]
        public int NoSubStringsUnsafe() => EvalNoSubStringsUnsafe.Evaluate(expression);
    }
    static class EvalOriginal
    {
        public static int Calc(string sInput)
        {
            int iCurrent = sInput.IndexOf(' ');
            int iResult = int.Parse(sInput.Substring(0, iCurrent));
            int iNext = 0;
            while ((iNext = sInput.IndexOf(' ', iCurrent + 4)) != -1)
            {
                iResult = Operate(iResult, sInput[iCurrent + 1], int.Parse(sInput.Substring((iCurrent + 3), iNext - (iCurrent + 2))));
                iCurrent = iNext;
            }
            return Operate(iResult, sInput[iCurrent + 1], int.Parse(sInput.Substring((iCurrent + 3))));
        }
    
        public static int Operate(int iReturn, char cOperator, int iOperant)
        {
            switch (cOperator)
            {
                case '+':
                    return (iReturn + iOperant);
                case '-':
                    return (iReturn - iOperant);
                case '*':
                    return (iReturn * iOperant);
                case '/':
                    return (iReturn / iOperant);
                default:
                    throw new Exception("Error");
            }
        }
    }
    static class EvalNoSubStrings {
        public static int Evaluate(string expression)
        {
            int offset = 0;
            SkipSpaces(expression, ref offset);
            int value = ReadInt32(expression, ref offset);
            while (ReadNext(expression, ref offset, out char @operator, out int operand))
            {
                switch (@operator)
                {
                    case '+': value = value + operand; break;
                    case '-': value = value - operand; break;
                    case '*': value = value * operand; break;
                    case '/': value = value / operand; break;
                    default: throw new Exception("Error");
                }
            }
            return value;
        }
        static bool ReadNext(string value, ref int offset,
            out char @operator, out int operand)
        {
            SkipSpaces(value, ref offset);
    
            if (offset >= value.Length)
            {
                @operator = (char)0;
                operand = 0;
                return false;
            }
    
            @operator = value[offset++];
            SkipSpaces(value, ref offset);
    
            if (offset >= value.Length)
            {
                operand = 0;
                return false;
            }
            operand = ReadInt32(value, ref offset);
            return true;
        }
    
        static void SkipSpaces(string value, ref int offset)
        {
            while (offset < value.Length && value[offset] == ' ') offset++;
        }
        static int ReadInt32(string value, ref int offset)
        {
            bool isNeg = false;
            char c = value[offset++];
            int i = (c - '0');
            if (c == '-')
            {
                isNeg = true;
                i = 0;
            }
    
            while (offset < value.Length && (c = value[offset++]) >= '0' && c <= '9')
                i = (i * 10) + (c - '0');
            return isNeg ? -i : i;
        }
    }
    
    static unsafe class EvalNoSubStringsUnsafe
    {
        public static int Evaluate(string expression)
        {
            
            fixed (char* ptr = expression)
            {
                int len = expression.Length;
                var c = ptr;
                SkipSpaces(ref c, ref len);
                int value = ReadInt32(ref c, ref len);
                while (len > 0 && ReadNext(ref c, ref len, out char @operator, out int operand))
                {
                    switch (@operator)
                    {
                        case '+': value = value + operand; break;
                        case '-': value = value - operand; break;
                        case '*': value = value * operand; break;
                        case '/': value = value / operand; break;
                        default: throw new Exception("Error");
                    }
                }
                return value;
            }
        }
        static bool ReadNext(ref char* c, ref int len,
            out char @operator, out int operand)
        {
            SkipSpaces(ref c, ref len);
    
            if (len-- == 0)
            {
                @operator = (char)0;
                operand = 0;
                return false;
            }
            @operator = *c++;
            SkipSpaces(ref c, ref len);
    
            if (len == 0)
            {
                operand = 0;
                return false;
            }
            operand = ReadInt32(ref c, ref len);
            return true;
        }
    
        static void SkipSpaces(ref char* c, ref int len)
        {
            while (len != 0 && *c == ' ') { c++;len--; }
        }
        static int ReadInt32(ref char* c, ref int len)
        {
            bool isNeg = false;
            char ch = *c++;
            len--;
            int i = (ch - '0');
            if (ch == '-')
            {
                isNeg = true;
                i = 0;
            }
    
            while (len-- != 0 && (ch = *c++) >= '0' && ch <= '9')
                i = (i * 10) + (ch - '0');
            return isNeg ? -i : i;
        }
    }
