    class StringHelper
    {
        static void Main(string[] args)
        {
            string str = "Hi my name is vikas bansal and my email id is bansal.vks@gmail.com";
            int offSet = 10;
            List<string> chunks = chunkMyStr(str, offSet);
            Console.Read();
        }
        static List<string> chunkMyStr(string str, int offSet)
        {
            List<string> resultChunks = new List<string>();
            for (int i = 0; i < str.Length; i += offSet)
            {
                string temp = str.Substring(i, (str.Length - i) > offSet ? offSet : (str.Length - i));
                Console.WriteLine(temp);
                resultChunks.Add(temp);
                
            }
            return resultChunks;
        }
    }
