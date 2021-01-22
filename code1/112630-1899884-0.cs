    var isOnlyNumbers = str.All(s =>
        {
            double i;
            return double.TryParse(s, out i);
        });
    Assert.IsFalse(isOnlyNumbers);
