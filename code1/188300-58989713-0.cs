          [Test]
          public void Test1() {
    
             var A = new Item(5);
             var B = new Item(3);
             var C = new Item(7);
             var D = new Item(2);
             var E = new Item(3);
    
             Item[][] result = AlgoToBuildBalancedPartition.Go(new[] { A, B, C, D, E }, t => t.Weight, 3);
             Assert.AreEqual(result.Length, 3);
             Assert.Contains(C, result[0]);
             Assert.Contains(A, result[1]);
             Assert.Contains(D, result[1]);
             Assert.Contains(B, result[2]);
             Assert.Contains(E, result[2]);
          }
    
          public static class AlgoToBuildBalancedPartition {
    
             public static T[][] Go<T>(
                    IEnumerable<T> seq,
                    Func<T, int> getWeightProc,
                    int maxNbPartitions) where T : class {
                Debug.Assert(!seq.IsNullOrEmpty());
                Debug.Assert(getWeightProc != null);
                Debug.Assert(maxNbPartitions >= 2);
    
                var partitions = new List<Partition<T>>(maxNbPartitions);
    
                T[] seqDescending = seq.OrderByDescending(getWeightProc).ToArray();
                int count = seqDescending.Length;
    
                for (var i = 0; i < count; i++) {
                   T item = seqDescending[i];
                   if (partitions.Count < maxNbPartitions) {
                      partitions.Add(new Partition<T>(item, getWeightProc));
                      continue;
                   }
    
                   // Get partition with smallest weight
                   Debug.Assert(partitions.Count == maxNbPartitions);
                   var partitionWithMinWeight = partitions[0];
                   for (var j = 1; j < maxNbPartitions; j++) {
                      var partition = partitions[j];
                      if (partition.TotalWeight > partitionWithMinWeight.TotalWeight) { continue; }
                      partitionWithMinWeight = partition;
                   }
    
                   partitionWithMinWeight.AddItem(item);
                }
    
                return partitions.Select(p => p.Items.ToArray()).ToArray();
             }
    
    
             private sealed class Partition<T> where T : class {
                internal Partition(T firstItem, Func<T, int> getWeightProc) {
                   Debug.Assert(firstItem != null);
                   Debug.Assert(getWeightProc != null);
                   m_GetWeightProc = getWeightProc;
                   AddItem(firstItem);
                }
                private readonly Func<T, int> m_GetWeightProc;
                internal List<T> Items { get; } = new List<T>();
                internal void AddItem(T item) {
                   Debug.Assert(item != null);
                   Items.Add(item);
                   TotalWeight += m_GetWeightProc(item);
                }
                internal int TotalWeight { get; private set; } = 0;
             }
          }
