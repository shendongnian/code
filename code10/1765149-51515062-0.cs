    [Test]
    public void SomethingSequenceNumberTest()
    {
        var lotsOfThings = new List<Something>
        {
            new Something { SequenceNumber = 1 },
            new Something { SequenceNumber = 2 },
            new Something { SequenceNumber = 4 },
            new Something { SequenceNumber = 3 },
        };
        // Assert that a sequence of integer are incremental, that there are no repetitions or gaps.
        var index = 1;
        lotsOfThings
            .OrderBy(t => t.SequenceNumber)
            .ToList()
            .ForEach(t =>
            {
                Assert.That(t.SequenceNumber, Is.EqualTo(index));
                index++;
            });
    }
