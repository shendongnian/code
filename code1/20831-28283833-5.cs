      var printer = new Stateprinter();
      printer.Configuration.Projectionharvester().Exclude<A>(x => x.X, x => x.Y);
      var sut = new A { X = DateTime.Now, Name = "Charly" };
      var expected = @"new A(){ Name = ""Charly""}";
      printer.Assert.PrintIsSame(expected, sut);
