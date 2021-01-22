        static void Main(string[] args) {            
            byte[] TestSubject = GetSource("SomeRandomFile.txt");
            //byte[] TestSubject = System.Text.ASCIIEncoding.ASCII.GetBytes("put any sample string you want to test here and uncomment this line");
            string TypicalAnswer = ByteArrayToHexViaByteManipulation(TestSubject);
            int Iterations = 15;
            double AverageRunTicks;
            Func<byte[], string> Method;
            string MethodDescription;
            Method = ByteArrayToHexStringViaStringBuilder;
            MethodDescription = "StringBuilderToStringFromBytes";
            AverageRunTicks = GetAverageRun(Method, TestSubject, TypicalAnswer, Iterations);
            Console.WriteLine(string.Format("{0}: {1}", MethodDescription, AverageRunTicks));
            Method = ByteArrayToHexStringViaBitConverter;
            MethodDescription = "BitConverterToStringFromBytes";
            AverageRunTicks = GetAverageRun(Method, TestSubject, TypicalAnswer, Iterations);
            Console.WriteLine(string.Format("{0}: {1}", MethodDescription, AverageRunTicks));
            Method = ByteArrayToHexStringViaArrayConvertAll;
            MethodDescription = "ArrayConvertAllToStringFromBytes";
            AverageRunTicks = GetAverageRun(Method, TestSubject, TypicalAnswer, Iterations);
            Console.WriteLine(string.Format("{0}: {1}", MethodDescription, AverageRunTicks));
            Method = ByteArrayToHexViaByteManipulation;
            MethodDescription = "ByteManipulationToCharArray";
            AverageRunTicks = GetAverageRun(Method, TestSubject, TypicalAnswer, Iterations);
            Console.WriteLine(string.Format("{0}: {1}", MethodDescription, AverageRunTicks));
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
        static byte[] GetSource(string fileName) {
            FileInfo TestSubjectFile = new System.IO.FileInfo(fileName);
            string TestFileContents = null;
            using (FileStream TestSubjectStream = TestSubjectFile.OpenRead()) {
                using (StreamReader TestSubjectReader = new StreamReader(TestSubjectStream)) {
                    TestFileContents = TestSubjectReader.ReadToEnd();
                }
            }
            return System.Text.ASCIIEncoding.ASCII.GetBytes(TestFileContents);
        }
        static double GetAverageRun(Func<byte[], string> operation, byte[] victim, string expectedOutput, int iterations) {
            string TestResult = operation(victim); // also primes anything that may be a one-time cost
            Debug.Assert(expectedOutput == TestResult);
            List<long> ElapsedTicksCollection = new List<long>();
            Stopwatch Timer;
            for (int i = 1; i <= iterations; i++) {
                Timer = Stopwatch.StartNew();
                operation(victim);
                Timer.Stop();
                ElapsedTicksCollection.Add(Timer.ElapsedTicks);
            }
            return ElapsedTicksCollection.Average();
        }
