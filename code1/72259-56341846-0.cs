    [Test]
    public void ToFriendlyDuration_produces_expected_result()
    {
        new DateTime(2019, 5, 28).ToFriendlyDuration(null).Should().Be("Until further notice");
        new DateTime(2019, 5, 28).ToFriendlyDuration(new DateTime(2020, 5, 28)).Should().Be("1 year");
        new DateTime(2019, 5, 28).ToFriendlyDuration(new DateTime(2021, 5, 28)).Should().Be("2 years");
        new DateTime(2019, 5, 28).ToFriendlyDuration(new DateTime(2021, 8, 28)).Should().Be("2 years, 3 months");
        new DateTime(2019, 5, 28).ToFriendlyDuration(new DateTime(2019, 8, 28)).Should().Be("3 months");
        new DateTime(2019, 5, 28).ToFriendlyDuration(new DateTime(2019, 8, 31)).Should().Be("3 months, 3 days");
        new DateTime(2019, 5, 1).ToFriendlyDuration(new DateTime(2019, 5, 31)).Should().Be("30 days");
        new DateTime(2010, 5, 28).ToFriendlyDuration(new DateTime(2020, 8, 28)).Should().Be("10 years, 3 months");
        new DateTime(2010, 5, 28).ToFriendlyDuration(new DateTime(2020, 5, 29)).Should().Be("10 years, 1 day");
    }
