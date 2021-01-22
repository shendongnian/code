    static void Main()
    {
        List<List<int>> collectionOfSeries = new List<List<int>>
                                    {   new List<int>(){1, 2, 3, 4, 5},
                                        new List<int>(){0, 1},
                                        new List<int>(){6,3},
                                        new List<int>(){1,3,5}
                                    };
        int[] result = new int[collectionOfSeries.Count];
    
        List<List<int>> combinations = GenerateCombinations(collectionOfSeries);
    
        Display(combinations); 
    }
     
