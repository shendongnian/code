	static void Main(string[] args) {
		FileInfo TestSubjectFile = new System.IO.FileInfo("SomeRandomFile.txt");
		string TestFileContents = null;
		using (FileStream TestSubjectStream = TestSubjectFile.OpenRead()) {
			using (StreamReader TestSubjectReader = new StreamReader(TestSubjectStream)) {
				TestFileContents = TestSubjectReader.ReadToEnd();
			}
		}
		byte[] TestSubject = System.Text.ASCIIEncoding.ASCII.GetBytes(TestFileContents);
		//byte[] TestSubject = System.Text.ASCIIEncoding.ASCII.GetBytes("put any sample string you want to test here and uncomment this line");
		List<long> ElapsedTicksCollection = new List<long>();
		ElapsedTicksCollection = new List<long>();
		for (int i = 1; i <= 1000; i++) {
			Stopwatch Timer = Stopwatch.StartNew();
			ByteArrayToHexStringViaStringBuilder(TestSubject);
			Timer.Stop();
			ElapsedTicksCollection.Add(Timer.ElapsedTicks);
		}
		Console.WriteLine(string.Format("StringBuilderToStringFromBytes: {0}", ElapsedTicksCollection.Average()));
		ElapsedTicksCollection = new List<long>();
		for (int i = 1; i <= 1000; i++) {
			Stopwatch Timer = Stopwatch.StartNew();
			ByteArrayToHexStringViaBitConverter(TestSubject);
			Timer.Stop();
			ElapsedTicksCollection.Add(Timer.ElapsedTicks);
		}
		Console.WriteLine(string.Format("BitConverterToStringFromBytes: {0}", ElapsedTicksCollection.Average()));
		ElapsedTicksCollection = new List<long>();
		for (int i = 1; i <= 1000; i++) {
			Stopwatch Timer = Stopwatch.StartNew();
			ByteArrayToHexStringViaArrayConvertAll(TestSubject);
			Timer.Stop();
			ElapsedTicksCollection.Add(Timer.ElapsedTicks);
		}
		Console.WriteLine(string.Format("ArrayConvertAllToStringFromBytes: {0}", ElapsedTicksCollection.Average()));
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
			hex.AppendFormat("{0:x2}", b);
		return hex.ToString();
	}
