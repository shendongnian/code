	public static void Main(string[] args) {
		var analyzer = new StandardAnalyzer(Version.LUCENE_30);
		var stream = analyzer.TokenStream("f", new StringReader("N.A.S.A. N.A.S.A"));
		var termAttr = stream.GetAttribute<ITermAttribute>();
		while (stream.IncrementToken()) {
			Console.WriteLine(termAttr.Term);
		}
		Console.ReadLine();
	}
