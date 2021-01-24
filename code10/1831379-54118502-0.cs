    public class A
    {
        public A(MssqlEntityHelper helper) { _bHelper = helper;  }
        internal readonly MssqlEntityHelper _bHelper;
        public int GetBag(string s1, string s2) {
            return _bHelper.GetBag(s1, s2);
        }
    }
    // Tests:
    [Fact]
    public void SampleTest() {
        var repo = new NS.B.A(Substitute.For<NS.B.MssqlEntityHelper>());
        repo._bHelper.GetBag(Arg.Any<string>(), Arg.Any<string>()).Returns(30);
        var result = repo.GetBag("oo", "L");
        Assert.True(result == 30);
    }
