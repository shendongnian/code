    IDictionary<string, int> dict = new Dictionary<string, int>();
    IDictionary<string, int> dictClone = new Dictionary<string, int>();
    
    for(int x = 0; x < 3; x++) {
    	dict[x.ToString()] = x;
    	dictClone[x.ToString()] = x;
    }
    
    CollectionAssert.AreEqual((System.Collections.ICollection)dict, (System.Collections.ICollection)dictClone);
