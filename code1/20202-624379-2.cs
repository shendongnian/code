    static void Main(string[] args) {
        byte[] testSubject = System.Text.ASCIIEncoding.ASCII.GetBytes("put any sample string you want to test here");
        Func<byte[], string>[] methodsToCheck = new Func<byte[], string>[] { ByteArrayToHexStringViaArrayConvertAll, ByteArrayToHexStringViaBitConverter, ByteArrayToHexStringViaStringBuilder, ByteArrayToHexViaByteManipulation };
        string typicalAnswer = methodsToCheck[0](testSubject);
        int iterations = 15;
            
        foreach (Func<byte[], string> method in methodsToCheck) {
            string methodDescription = method.Method.Name;
            double averageRunTicks = GetAverageRun(method, testSubject, typicalAnswer, iterations);
            Console.WriteLine(string.Format("{0}: {1}", methodDescription, averageRunTicks));
        }
        Console.Read();
    }
    static string ByteArrayToHexStringViaArrayConvertAll(byte[] ba) {
        return string.Join(string.Empty, Array.ConvertAll(ba, x => x.ToString("X2")));
    }
    static string ByteArrayToHexStringViaBitConverter(byte[] ba) {
        string hex = BitConverter.ToString(ba);
        return hex.Replace("-", "");
    }
    static string ByteArrayToHexStringViaStringBuilder(byte[] ba) {
        StringBuilder hex = new StringBuilder(ba.Length * 2);
        foreach (byte b in ba)
            hex.AppendFormat("{0:X2}", b);
        return hex.ToString();
    }
    static string ByteArrayToHexViaByteManipulation(byte[] ba) {
        char[] c = new char[ba.Length * 2];
        byte b;
        for (int i = 0; i < ba.Length; i++) {
            b = ((byte)(ba[i] >> 4));
            c[i * 2] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            b = ((byte)(ba[i] & 0xF));
            c[i * 2 + 1] = (char)(b > 9 ? b + 0x37 : b + 0x30);
        }
        return new string(c);
    }
    static double GetAverageRun(Func<byte[], string> operation, byte[] victim, string expectedOutput, int iterations) {
        string testResult = operation(victim); // also primes anything that may be a one-time cost
        Debug.Assert(expectedOutput == testResult);
        List<long> elapsedTicksCollection = new List<long>();
        Stopwatch timer;
        for (int i = 1; i <= iterations; i++) {
            timer = Stopwatch.StartNew();
            operation(victim);
            timer.Stop();
            elapsedTicksCollection.Add(timer.ElapsedTicks);
        }
        return elapsedTicksCollection.Average();
    }
