    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    
    namespace NetMandelbrot
    {
            public class InterlacePartitioner : Partitioner<int>
            {
                int ImageHeight = 0;
    
                public InterlacePartitioner(int imageHeight)
                {
                    ImageHeight = imageHeight;
                }
    
                public override IList<IEnumerator<int>> GetPartitions(int partitionCount)
                {
                    List<List<int>> partz = new List<List<int>>();
    
                    int[] lines = GetLines();
                    for (int i = 0; i < lines.Length; i++)
                    {
                        partz[i%partitionCount].Add(lines[i]);
                    }
                    return (IList<IEnumerator<int>>)partz;
                }
    
                // Interlace Y-Lines using GIF Interlaced method
                int[] GetLines()
                {
                    var ylace = new int[ImageHeight];
                    for (int y = 0, yg = 0, yy = 0; y < ImageHeight; y++)
                    {
                        ylace[y] = yy;
    
                        if (yg == 0 || yg == 1)
                            yy += 8;
                        else if (yg == 2)
                            yy += 4;
                        else if (yg == 3)
                            yy += 2;
    
                        if (yy >= ImageHeight)
                        {
                            yg = (yg + 1) % 4;
                            if (yg == 1) yy = 4;
                            else if (yg == 2) yy = 2;
                            else if (yg == 3) yy = 1;
                            else if (yg == 0) yy = 0;
                        }
                    }
    
                    return ylace;
                }
    
                public override IEnumerable<int> GetDynamicPartitions()
                {
                    throw new NotImplementedException();
                }
    
                // Not consumable from Parallel.ForEach.
                public override bool SupportsDynamicPartitions
                {
                    get
                    {
                        return false;
                    }
                }
        } //end of class
    }
