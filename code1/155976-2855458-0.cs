    public class Xyz
    {
        public virtual string AA { set{} }
    }
    public class VerifySyntax
    {
        [Fact]
        public void ThisIsHow()
        {
            var xyz = new Mock<Xyz>();
            xyz.Object.AA = "bb";
            // Throws:
            xyz.VerifySet( s => s.AA = It.IsAny<string>(), Times.Never() );
        }
    }
    public class SetupSyntax
    {
        [Fact]
        public void ThisIsHow()
        {
            var xyz = new Mock<Xyz>();
            xyz.SetupSet( s => s.AA = It.IsAny<string>() ).Throws( new InvalidOperationException(  ) );
            Assert.Throws<InvalidOperationException>( () => xyz.Object.AA = "bb" );
        }
    }
