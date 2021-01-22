        namespace ConsoleApplication1
        {
            class Program
            {
                static void Main(string[] args)
                {
                    string[] files = Directory.GetFiles("C:\\Windows")
                            .Select(x => new Tuple<string, string>(x, FirstLine(x)))
                            .OrderBy(x => x.Item2)
                            .Select(x => x.Item1).ToArray();
                }
                static string FirstLine(string path)
                {
                    using (TextReader tr = new StreamReader(
                                File.Open(path, FileMode.Open)))
                    {
                        return tr.ReadLine();
                    }
                }
            }
        }
