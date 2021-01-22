    [Test]  
    public void TestOfDateTime()  
    {  
          var firstValue = DateTime.Now;
          MDateTime.NowGet = () => new DateTime(2000,1,1);
          var secondValue = DateTime.Now;
          Assert(firstValue > secondValue); // would be false if 'moleing' failed
    }
