    class Thing
    {
      public int Foo { get; set; }
      public int Bar { get; set; }
      public string Baz { get; set; }
    }
    [TestMethod]
    public void ListToMapTest()
    {
      var things = new List<Thing>
                 {
                     new Thing {Foo = 3, Bar = 3, Baz = "quick"},
                     new Thing {Foo = 3, Bar = 4, Baz = "brown"},
                     new Thing {Foo = 6, Bar = 3, Baz = "fox"},
                     new Thing {Foo = 6, Bar = 4, Baz = "jumps"}
                 };
      var thingMap = Map<int, int, string>.From(things, t => t.Foo, t => t.Bar, t => t.Baz);
      Assert.IsTrue(thingMap.ContainsKey(3, 4));
      Assert.AreEqual("brown", thingMap[3, 4]);
      thingMap.DefaultValue = string.Empty;
      Assert.AreEqual("brown", thingMap[3, 4]);
      Assert.AreEqual(string.Empty, thingMap[3, 6]);
      thingMap.DefaultGeneration = (k1, k2) => (k1.ToString() + k2.ToString());
      Assert.IsFalse(thingMap.ContainsKey(3, 6));
      Assert.AreEqual("36", thingMap[3, 6]);
      Assert.IsTrue(thingMap.ContainsKey(3, 6));
    }
