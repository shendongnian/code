                // var myShufledKeys = myDictionary.Shuffle(); // Sample
                // var myShufledValue = myDictionary[myShufledKeys[0]]; // Sample
                // Easy Sample
                var myObjects = System.Linq.Enumerable.Range(0, 4);
                foreach(int i in myObjects)
                    myDictionary.Add(i, string.Format("myValueObjectNumber: {0}", i));
                
                var myShufledKeys = myDictionary.Shuffle();
                var myShufledValue = myDictionary[myShufledKeys[0]];
