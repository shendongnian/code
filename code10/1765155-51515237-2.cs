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
	
        // extract the sequence numbers into a list
	    var sequenceNumbers = lotsOfThings.Select(x => x.SequenceNumber)	                               
		    						      .ToList();
	    sequenceNumbers.Sort();
	
        // Enumerable.Range will create a new enumerable
        // with values ranging from .First() to .Last(),
        // i.e. [1, 2, 3, 4]
	    Assert.IsTrue(Enumerable.Range(sequenceNumbers.First(), sequenceNumbers.Last())
                                .SequenceEqual(sequenceNumbers));
    }
