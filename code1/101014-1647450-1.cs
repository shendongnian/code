    [TestFixture]
    public class ExpressionsExTests
    {
        class NumbNut
        {
            public const string Name = "blah";
            public static bool Surname { get { return false; } }
            public string Lame;
            public readonly List<object> SerendipityCollection = new List<object>();
            public static int Age { get { return 12; }}
            public static bool IsMammel { get { return _isMammal; } }
            private const bool _isMammal = true;
            internal static string BiteMe() { return "bitten"; }
        }
        [Test]
        public void NodeTypeIs_Convert_aka_UnaryExpression_Ok()
        {
            Assert.That(ExpressionsEx.GetPropertyName<NumbNut>(nn => NumbNut.Age), Is.EqualTo("Age"));
            Assert.That(ExpressionsEx.GetPropertyName<NumbNut>(nn => NumbNut.IsMammel), Is.EqualTo("IsMammel"));
            Assert.That(ExpressionsEx.GetPropertyName<NumbNut>(nn => NumbNut.Surname), Is.EqualTo("Surname"));
        }
        [Test]
        public void NodeTypeIs_MemberAccess_aka_MemberExpression_Ok()
        {
            Assert.That(ExpressionsEx.GetPropertyName<NumbNut>(nn => nn.SerendipityCollection), Is.EqualTo("SerendipityCollection"));
            Assert.That(ExpressionsEx.GetPropertyName<NumbNut>(nn => nn.Lame), Is.EqualTo("Lame"));
        }
        [Test]
        public void NodeTypeIs_Call_Error()
        {
            CommonAssertions.PreconditionCheck(() => ExpressionsEx.GetPropertyName<NumbNut>(nn => NumbNut.BiteMe()),
                                               "does not refer to a property and is therefore not supported");
        }
        [Test]
        public void NodeTypeIs_Constant_Error() {
            CommonAssertions.PreconditionCheck(() => ExpressionsEx.GetPropertyName<NumbNut>(nn => NumbNut.Name),
                                               "does not refer to a property and is therefore not supported");
        }
        [Test]
        public void IfExpressionIsNull_Error()
        {
            CommonAssertions.NotNullRequired(() => ExpressionsEx.GetPropertyName<NumbNut>(null));
        }
        [Test]
        public void WasPropertyChanged_IfPassedNameIsSameAsNameOfPassedExpressionMember_True()
        {
            Assert.That(ExpressionsEx.WasPropertyChanged<NumbNut>("SerendipityCollection", nn => nn.SerendipityCollection), Is.True);
        }
        [Test]
        public void WasPropertyChanged_IfPassedPropertyChangeArgNameIsSameAsNameOfPassedExpressionMember_True()
        {
            var args = new PropertyChangedEventArgs("SerendipityCollection");
            Assert.That(ExpressionsEx.WasPropertyChanged<NumbNut>(args, nn => nn.SerendipityCollection), Is.True);
        }
    }
