    private class Sequence
    {
        public int FirstArray { get; set; }
        public int SecondArray { get; set; }
        public IList<int> Nums { get; set; }
    }
 
    var sequences = new List<Sequence>();
    for (var i = 0; i < arrays.Length-1; i++)
    {
        List<Sequence> relevantSequences = null;
        for (var j = 0; j < arrays[i].Length - 1; j++)
        {
            var num = arrays[i][j];
            var nextNum = arrays[i][j+1];
            var flows = transitions[num].Where(x => x.NextNum == nextNum && x.ArrayNum > i).ToList();
            if (!flows.Any())
            {
                if (relevantSequences != null)
                {
                    sequences.AddRange(relevantSequences);
                    relevantSequences = null;
                }
            }
            else 
            {
                if (relevantSequences == null)
                {
                    relevantSequences = flows.Select(x => new Sequence { FirstArray = i, SecondArray = x.ArrayNum, Nums = new List<int> {num, nextNum} }).ToList();
                }
                else
                {
                    foreach (var flow in flows)
                    {
                        var sequence = relevantSequences.SingleOrDefault(x => x.SecondArray == flow.ArrayNum);
    
                        if (sequence != null)
                        {
                            sequence.Nums.Add(nextNum);
                        }
                        else
                        {
                            relevantSequences.Add(new Sequence { FirstArray = i, SecondArray = flow.ArrayNum, Nums = new List<int> { num, nextNum } });
                        }
                    }
                }
            }
                        
        }
    
        if (relevantSequences != null)
            sequences.AddRange(relevantSequences);
    }
