    static void Main(string[] args)
            {
                int[] pathNodes = new int[] {1,2,3,4,5};
                int[] optionalNodes = new int[] { 1, 4, 5 };
    
                List<int[]> combies = ProduceCombinations(pathNodes, optionalNodes);
    
            }
    
            public static List<int[]> ProduceCombinations(int[] PathNodes, int[] OptionalNodes)
            {
                List<int[]> results = new List<int[]>();
                results.Add((int[])PathNodes.Clone());
                int index = 0;
                for (int j = 0; j < OptionalNodes.Length; j++)
                {
                    while (PathNodes[index] < OptionalNodes[j]) index++;
    
                    int lenght = results.Count;
                    for(int i = 0; i < lenght; i++)
                    {
                        var newSol = (int[])results[i].Clone();
                        newSol[index] = 0;
                        results.Add(newSol);
                    }
                }
                
                return results;
            }
