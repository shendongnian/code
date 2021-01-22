	[TestClass]
	public class EnumExtensionsTests
	{
		[Flags]
		enum WithFlags
		{
			First = 1,
			Second = 2,
			Third = 4,
			Fourth = 8
		}
		enum WithoutFlags
		{
			First = 1,
			Second = 22,
			Third = 55,
			Fourth = 13,
			Fifth = 127
		}
		enum WithoutNumbers
		{
			First, // 1
			Second, // 2
			Third, // 3
			Fourth // 4
		}
		enum WithoutFirstNumberAssigned
		{
			First = 7,
			Second, // 8
			Third, // 9
			Fourth // 10
		}
		enum WithNagativeNumbers
		{
			First = -7,
			Second = -8,
			Third = -9,
			Fourth = -10
		}
		[TestMethod]
		public void IsValidEnumTests()
		{
			Assert.IsTrue(((WithFlags)(1 | 4)).IsValid());
			Assert.IsTrue(((WithFlags)(1 | 4)).IsValid());
			Assert.IsTrue(((WithFlags)(1 | 4 | 2)).IsValid());
			Assert.IsTrue(((WithFlags)(2)).IsValid());
			Assert.IsTrue(((WithFlags)(3)).IsValid());
			Assert.IsTrue(((WithFlags)(1 + 2 + 4 + 8)).IsValid());
			Assert.IsFalse(((WithFlags)(16)).IsValid());
			Assert.IsFalse(((WithFlags)(17)).IsValid());
			Assert.IsFalse(((WithFlags)(18)).IsValid());
			Assert.IsFalse(((WithFlags)(0)).IsValid());
			Assert.IsTrue(((WithoutFlags)1).IsValid());
			Assert.IsTrue(((WithoutFlags)22).IsValid());
			Assert.IsTrue(((WithoutFlags)(53 | 6)).IsValid());	 // Will end up being Third
			Assert.IsTrue(((WithoutFlags)(22 | 25 | 99)).IsValid()); // Will end up being Fifth
			Assert.IsTrue(((WithoutFlags)55).IsValid());
			Assert.IsTrue(((WithoutFlags)127).IsValid());
			Assert.IsFalse(((WithoutFlags)48).IsValid());
			Assert.IsFalse(((WithoutFlags)50).IsValid());
			Assert.IsFalse(((WithoutFlags)(1 | 22)).IsValid());
			Assert.IsFalse(((WithoutFlags)(9 | 27 | 4)).IsValid());
			Assert.IsTrue(((WithoutNumbers)0).IsValid());
			Assert.IsTrue(((WithoutNumbers)1).IsValid());
			Assert.IsTrue(((WithoutNumbers)2).IsValid());
			Assert.IsTrue(((WithoutNumbers)3).IsValid());
			Assert.IsTrue(((WithoutNumbers)(1 | 2)).IsValid());	// Will end up being Third
			Assert.IsTrue(((WithoutNumbers)(1 + 2)).IsValid());	// Will end up being Third
			Assert.IsFalse(((WithoutNumbers)4).IsValid());
			Assert.IsFalse(((WithoutNumbers)5).IsValid());
			Assert.IsFalse(((WithoutNumbers)25).IsValid());
			Assert.IsFalse(((WithoutNumbers)(1 + 2 + 3)).IsValid());
			Assert.IsTrue(((WithoutFirstNumberAssigned)7).IsValid());
			Assert.IsTrue(((WithoutFirstNumberAssigned)8).IsValid());
			Assert.IsTrue(((WithoutFirstNumberAssigned)9).IsValid());
			Assert.IsTrue(((WithoutFirstNumberAssigned)10).IsValid());
			Assert.IsFalse(((WithoutFirstNumberAssigned)11).IsValid());
			Assert.IsFalse(((WithoutFirstNumberAssigned)6).IsValid());
			Assert.IsFalse(((WithoutFirstNumberAssigned)(7 | 9)).IsValid());
			Assert.IsFalse(((WithoutFirstNumberAssigned)(8 + 10)).IsValid());
			Assert.IsTrue(((WithNagativeNumbers)(-7)).IsValid());
			Assert.IsTrue(((WithNagativeNumbers)(-8)).IsValid());
			Assert.IsTrue(((WithNagativeNumbers)(-9)).IsValid());
			Assert.IsTrue(((WithNagativeNumbers)(-10)).IsValid());
			Assert.IsFalse(((WithNagativeNumbers)(-11)).IsValid());
			Assert.IsFalse(((WithNagativeNumbers)(7)).IsValid());
			Assert.IsFalse(((WithNagativeNumbers)(8)).IsValid());
		}
    }
