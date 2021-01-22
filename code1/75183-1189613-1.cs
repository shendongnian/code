    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "cat,dog,\"0 = OFF, 1 = ON\",lion,tiger,'R = red, G = green,     B = blue',bear"; 
            Console.WriteLine("\nmyString is ...\n\t" + myString + "\n");
            CsvParser parser = new CsvParser(myString);
    
            Int32 lineNumber = 0;
            foreach (string s in parser)
            {
                Console.WriteLine(lineNumber + ": " + s);
            }
    
            Console.ReadKey();
        }
    }
    
    internal enum TokenType
    {
        Comma,
        Quote,
        Value
    }
    
    internal class Token
    {
        public Token(TokenType type, string value)
        {
            Value = value;
            Type = type;
        }
    
        public String Value { get; private set; }
        public TokenType Type { get; private set; }
    }
    
    internal class StreamTokenizer : IEnumerable<Token>
    {
        private TextReader _reader;
    
        public StreamTokenizer(TextReader reader)
        {
            _reader = reader;    
        }
    
        public IEnumerator<Token> GetEnumerator()
        {
            String line;
            StringBuilder value = new StringBuilder();
    
            while ((line = _reader.ReadLine()) != null)
            {
                foreach (Char c in line)
                {
                    switch (c)
                    {
                        case '\'':
                        case '"':
                            if (value.Length > 0)
                            {
                                yield return new Token(TokenType.Value, value.ToString());
                                value.Length = 0;
                            }
                            yield return new Token(TokenType.Quote, c.ToString());
                            break;
                        case ',':
                           if (value.Length > 0)
                            {
                                yield return new Token(TokenType.Value, value.ToString());
                                value.Length = 0;
                            }
                            yield return new Token(TokenType.Comma, c.ToString());
                            break;
                        default:
                            value.Append(c);
                            break;
                    }
                }
                
                // Thanks, dpan
                if (value.Length > 0) 
                {
                    yield return new Token(TokenType.Value, value.ToString()); 
                }
            }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    internal class CsvParser : IEnumerable<String>
    {
        private StreamTokenizer _tokenizer;
    
        public CsvParser(Stream data)
        {
            _tokenizer = new StreamTokenizer(new StreamReader(data));
        }
    
        public CsvParser(String data)
        {
            _tokenizer = new StreamTokenizer(new StringReader(data));
        }
    
        public IEnumerator<string> GetEnumerator()
        {
            Boolean inQuote = false;
            StringBuilder result = new StringBuilder();
    
            foreach (Token token in _tokenizer)
            {
                switch (token.Type)
                {
                    case TokenType.Comma:
                        if (inQuote)
                        {
                            result.Append(token.Value);
                        }
                        else
                        {
                            yield return result.ToString();
                            result.Length = 0;
                        }
                        break;
                    case TokenType.Quote:
                        // Toggle quote state
                        inQuote = !inQuote;
                        break;
                    case TokenType.Value:
                        result.Append(token.Value);
                        break;
                    default:
                        throw new InvalidOperationException("Unknown token type: " +    token.Type);
                }
            }
    
            if (result.Length > 0)
            {
                yield return result.ToString();
            }
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
