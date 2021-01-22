       public static int GetLongestSequenceOfSameCharacters(this string sequence)
            {
                var data = new List<char>();
                for (int i = 0; i < sequence.Length; i++)
                {
                    if (i > 0 && (sequence[i] == sequence[i - 1]))
                    {
                        data.Add(sequence[i]);
                    }               
                }
    
                return data.GroupBy(x => x).Max(x => x.Count()) + 1;
            }
     [TestMethod]
            public void TestMethod1()
            {
                // Arrange
                string sequence = "aabbbbccccce";
    
                // Act
                int containsSameNumbers = sequence.GetLongestSequenceOfSameCharacters();
    
                // Assert
                Assert.IsTrue(containsSameNumbers == 5);
    
            }
