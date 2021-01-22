	[TestMethod]
	public void TestFilenameAttribute()
	{
		var rxa = new ValidFileNameAttribute();
		Assert.IsFalse(rxa.IsValid("pptx."));
		Assert.IsFalse(rxa.IsValid("pp.tx."));
		Assert.IsFalse(rxa.IsValid("."));
		Assert.IsFalse(rxa.IsValid(".pp.tx"));
		Assert.IsFalse(rxa.IsValid(".pptx"));
		Assert.IsFalse(rxa.IsValid("pptx"));
		Assert.IsFalse(rxa.IsValid("a/abc.pptx"));
		Assert.IsFalse(rxa.IsValid("a\\abc.pptx"));
		Assert.IsFalse(rxa.IsValid("c:abc.pptx"));
		Assert.IsFalse(rxa.IsValid("c<abc.pptx"));
		Assert.IsTrue(rxa.IsValid("abc.pptx"));
		rxa = new ValidFileNameAttribute { AllowedExtensions = ".pptx" };
		Assert.IsFalse(rxa.IsValid("abc.docx"));
		Assert.IsTrue(rxa.IsValid("abc.pptx"));
	}
