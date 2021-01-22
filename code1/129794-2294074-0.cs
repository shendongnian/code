    using System;
    using System.Collections.Generic;
    
    namespace Juliet
    {
        interface IToken<T>
        {
            bool IsDelimeter { get; }
            T Data { get; }
        }
    
        class DelimeterToken<T> : IToken<T>
        {
            public bool IsDelimeter { get { return true; } }
            public T Data { get { throw new Exception("No data"); } }
        }
    
        class DataToken<T> : IToken<T>
        {
            public DataToken(T data)
            {
                this.Data = data;
            }
    
            public bool IsDelimeter { get { return false; } }
            public T Data { get; private set; }
        }
    
        class TokenFactory<T>
        {
            public IToken<T> Make()
            {
                return new DelimeterToken<T>();
            }
    
            public IToken<T> Make(T data)
            {
                return new DataToken<T>(data);
            }
        }
    
        class Program
        {
    
            static List<List<T>> SplitTokens<T>(IEnumerable<IToken<T>> tokens)
            {
                List<List<T>> res = new List<List<T>>();
                foreach (IToken<T> token in tokens)
                {
                    if (token.IsDelimeter)
                    {
                        res.Add(new List<T>());
                    }
                    else
                    {
                        if (res.Count == 0)
                        {
                            res.Add(new List<T>());
                        }
    
                        res[res.Count - 1].Add(token.Data);
                    }
                }
    
                return res;
            }
    
            static void Main(string[] args)
            {
                TokenFactory<string> factory = new TokenFactory<string>();
                IToken<string>[] tokens = new IToken<string>[]
                    {
                        factory.Make("a"), factory.Make("b"), factory.Make("c"), factory.Make(),
                        factory.Make("d"), factory.Make("e"), factory.Make(),
                        factory.Make("f"), factory.Make("g"), factory.Make("h"), factory.Make(),
                        factory.Make("i"), factory.Make("j"), factory.Make("k"), factory.Make("l"), factory.Make(),
                        factory.Make("m")
                    };
    
                List<List<string>> splitTokens = SplitTokens(tokens);
                for (int i = 0; i < splitTokens.Count; i++)
                {
                    Console.Write("{");
                    for (int j = 0; j < splitTokens[i].Count; j++)
                    {
                        Console.Write("{0}, ", splitTokens[i][j]);
                    }
                    Console.Write("}");
                }
    
                Console.ReadKey(true);
            }
        }
    }
