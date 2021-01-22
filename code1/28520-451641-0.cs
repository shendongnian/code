	public class Address
	{
		private string _first;
		private string _last;
		private string _name;
		private string _domain;
		public Address(string first, string last, string name, string domain)
		{
			_first = first;
			_last = last;
			_name = name;
			_domain = domain;
		}
		public string First
		{
			get { return _first; }
		}
		public string Last
		{
			get { return _last; }
		}
		public string Name
		{
			get { return _name; }
		}
		public string Domain
		{
			get { return _domain; }
		}
	}
    [TestFixture]
	public class RegexEmailTest
	{
		[Test]
		public void TestThreeEmailAddresses()
		{
			Regex emailAddress = new Regex(
				@"((?<last>\w*), (?<first>\w*) <(?<name>\w*)@(?<domain>\w*\.\w*)>)|" +
				@"((?<first>\w*) (?<last>\w*) <(?<name>\w*)@(?<domain>\w*\.\w*)>)|" +
				@"((?<name>\w*)@(?<domain>\w*\.\w*))");
			string input = "First, Last <name@domain.com>, name@domain.com, First Last <name@domain.com>";
			MatchCollection matches = emailAddress.Matches(input);
			List<Address> addresses =
				(from Match match in matches
				 select new Address(
					 match.Groups["first"].Value,
					 match.Groups["last"].Value,
					 match.Groups["name"].Value,
					 match.Groups["domain"].Value)).ToList();
			Assert.AreEqual(3, addresses.Count);
			Assert.AreEqual("Last", addresses[0].First);
			Assert.AreEqual("First", addresses[0].Last);
			Assert.AreEqual("name", addresses[0].Name);
			Assert.AreEqual("domain.com", addresses[0].Domain);
			Assert.AreEqual("", addresses[1].First);
			Assert.AreEqual("", addresses[1].Last);
			Assert.AreEqual("name", addresses[1].Name);
			Assert.AreEqual("domain.com", addresses[1].Domain);
			Assert.AreEqual("First", addresses[2].First);
			Assert.AreEqual("Last", addresses[2].Last);
			Assert.AreEqual("name", addresses[2].Name);
			Assert.AreEqual("domain.com", addresses[2].Domain);
		}
	}
