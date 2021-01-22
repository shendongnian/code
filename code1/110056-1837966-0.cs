    pubilc class Calc {
        public int DoubleIt(string a) {
            return ToInt(a)*2;
        }
        
        public virtual int ToInt(string s) {
            return int.Parse(s);
        }
    }
    
    // The test:
    var mock = new Mock<Calc>();
    string parameterPassed = null;
    mock.Setup(c => x.ToInt(It.Is.Any<int>())).Returns(3).Callback(s => parameterPassed = s);
    
    mock.Object.DoubleIt("3");
    Assert.AreEqual("3", parameterPassed);
