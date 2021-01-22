      var cfg = ConfigurationHelper.GetStandardConfiguration(" ");
      cfg.Projectionharvester().Exclude<A>(x => x.X, x => x.Y);
      var printer = new Stateprinter(cfg);
      var sut = new A { X = DateTime.Now, Name = "Charly" };
      var actual = printer.PrintObject();
      var expected = @"new A(){ Name = ""Charly""}";
      printer.Assert.AreEqual(expected, actual.Replace("\r\n", ""));
