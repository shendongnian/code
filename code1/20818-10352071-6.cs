    public void SomeTest()
    {
        var expect = new { PropA = 12, PropB = 14 };
        var sut = loc.Resolve<SomeSvc>();
        var bigObjectResult = sut.Execute(); // This will return a big object with loads of properties 
        AssExt.AreEqualByJson(expect, new { bigObjectResult.PropA, bigObjectResult.PropB });
    }
