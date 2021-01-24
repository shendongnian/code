        public void AssertIsSequenced<T>(List<T> list, Func<T, int> valueExtractor)
        {
            int? lastExtractedValue = null;
            foreach (T item in list)
            {
                int extractedValue = valueExtractor(item);
                if (lastExtractedValue != null && extractedValue != lastExtractedValue + 1)
                {
                    Assert.Fail($"{extractedValue} after {lastExtractedValue} does not follow the sequence rule.");
                }
                lastExtractedValue = extractedValue;
            }
        }
        [TestMethod]
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
            AssertIsSequenced(lotsOfThings, something => something.SequenceNumber);
        }
