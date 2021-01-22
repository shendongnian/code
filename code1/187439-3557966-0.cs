    [TestFixture]
    public class TestsOne{
        [Test] public void TryOne(){
            Helpers.ValidateString("Work?");
        }
    }
    
    [TestFixture]
    public class TestsTwo{
        [Test] public void TryTwo(){
            Helpers.ValidateString("Work?");
        }
    }
    
    public static class Helpers{
        public static void ValidateString(string s){
            Assert.IsNotNull(s);
        }
    }
