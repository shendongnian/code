	class Test
	{
		public Test(string name, params Test[] children)
		{
			Print = (Action<StringBuilder>)Delegate.Combine(
				new Action<StringBuilder>(delegate(StringBuilder sb) { sb.AppendLine(this.Name); }),
				new Action<StringBuilder>(delegate(StringBuilder sb) { sb.AppendLine(this.Name); })
			);
			Name = name;
			Children = children;
		}
		public string Name;
		public Test[] Children;
		public Action<StringBuilder> Print;
	}
	static void Main(string[] args)
	{
		Dictionary<string, Test> data2, data = new Dictionary<string, Test>(StringComparer.OrdinalIgnoreCase);
		Test a, b, c;
		data.Add("a", a = new Test("a", new Test("a.a")));
		a.Children[0].Children = new Test[] { a };
		data.Add("b", b = new Test("b", a));
		data.Add("c", c = new Test("c"));
		data2 = Clone(data);
		Assert.IsFalse(Object.ReferenceEquals(data, data2));
		//basic contents test & comparer
		Assert.IsTrue(data2.ContainsKey("a"));
		Assert.IsTrue(data2.ContainsKey("A"));
		Assert.IsTrue(data2.ContainsKey("B"));
		//nodes are different between data and data2
		Assert.IsFalse(Object.ReferenceEquals(data["a"], data2["a"]));
		Assert.IsFalse(Object.ReferenceEquals(data["a"].Children[0], data2["a"].Children[0]));
		Assert.IsFalse(Object.ReferenceEquals(data["B"], data2["B"]));
		Assert.IsFalse(Object.ReferenceEquals(data["B"].Children[0], data2["B"].Children[0]));
		Assert.IsFalse(Object.ReferenceEquals(data["B"].Children[0], data2["A"]));
		//graph intra-references still in tact?
		Assert.IsTrue(Object.ReferenceEquals(data["B"].Children[0], data["A"]));
		Assert.IsTrue(Object.ReferenceEquals(data2["B"].Children[0], data2["A"]));
		Assert.IsTrue(Object.ReferenceEquals(data["A"].Children[0].Children[0], data["A"]));
		Assert.IsTrue(Object.ReferenceEquals(data2["A"].Children[0].Children[0], data2["A"]));
		data2["A"].Name = "anew";
		StringBuilder sb = new StringBuilder();
		data2["A"].Print(sb);
		Assert.AreEqual("anew\r\nanew\r\n", sb.ToString());
	}
