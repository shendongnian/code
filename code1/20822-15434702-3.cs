    [TestFixture]
    class PortfolioTests
    {
        [Test]
        public void TestPortfolioEquality()
        {
            Portfolio LeftObject 
                = Portfolio.GetDefault();
            Portfolio RightObject 
                = Portfolio.GetPortfolio("{{GNOME}}", "{{NONE}}", "{{NONE}}");
            Assert.That( LeftObject, PortfolioState.Matches( RightObject ) );
        }
    }
