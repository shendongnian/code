            var thisOnePasses = new List<int> {2}; // collection initializer
            var thisOneFails = new List<int> (2);  // oops, use capacity by mistake #gotcha#
            thisOnePasses.Count.Should().Be(1);
            thisOnePasses.First().Should().Be(2);
            thisOneFails.Count.Should().Be(1);
            thisOneFails.First().Should().Be(2);
