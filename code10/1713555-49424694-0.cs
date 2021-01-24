    static class P
    {
        static void Main()
        {
            string input = "14 + 2 * 32 / 60 + 43 - 7 + 3 - 1 + 0 * 7 + 87 - 32 / 34";
    
            var val = Evaluate(input);
            System.Console.WriteLine(val);
        }
        static int Evaluate(string expression)
        {
            int offset = 0;
            SkipSpaces(expression, ref offset);
            int value = ReadInt32(expression, ref offset);
            while(ReadNext(expression, ref offset, out char @operator, out int operand))
            {
                switch(@operator)
                {
                    case '+': value = value + operand; break;
                    case '-': value = value - operand; break;
                    case '*': value = value * operand; break;
                    case '/': value = value / operand; break;
                }
            }
            return value;
        }
        static bool ReadNext(string value, ref int offset,
            out char @operator, out int operand)
        {
            SkipSpaces(value, ref offset);
    
            if(offset >= value.Length)
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
            if(c == '-')
            {
                isNeg = true;
                i = 0;
                // todo: what to do here if `-` is not followed by [0-9]?
            }
    
            while (offset < value.Length && (c = value[offset++]) >= '0' && c <= '9')
                i = (i * 10) + (c - '0');
            return isNeg ? -i : i;
        }
    }
