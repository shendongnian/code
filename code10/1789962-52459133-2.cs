    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    using System.Collections;
    
    namespace NetMandelbrot
    {
        // This is both the Interlaced Line IEnumerator and IEnumerable 
        public class ImageInterlace : 
            IEnumerable<int>, IEnumerable, IEnumerator<int>, IDisposable
        {
            int[] Lines;
            int Pos;
    
            public ImageInterlace(int ImageHeight)
            {
                Lines = GetLines(ImageHeight);
            }
    
            // Interlace Y-Lines using GIF Interlaced method
            int[] GetLines(int ImageHeight)
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
    
            #region Implementation of IDisposable
    
            public void Dispose()
            {
            }
    
            #endregion
    
            #region Implementation of IEnumerable<int>
            public IEnumerator<int> GetEnumerator()
            {
                return this;
            }
            #endregion
    
            // Legacy C#
            #region Implementation of IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;
            }
            #endregion
    
            #region Implementation of IEnumerator<int>
            public bool MoveNext()
            {
                bool done;
                lock (Lines)
                {
                    if (Pos > Lines.Length)
                    {
                        done = true;
                    }
                    else
                    {
                        Pos++;
                        done = false;
    
                    }
                }
                return done;
            }
    
            public void Reset()
            {
                lock (Lines)
                {
                    Pos = 0;
                }
            }
    
            public int Current
            {
                get
                {
                    int nextline;
                    lock (Lines)
                    {
                        if (Pos > Lines.Length)
                        {
                            nextline = -1;
                        }
                        else
                        {
                            nextline = Lines[Pos];
                        }
                    }
                    return nextline;
                }
            }
    
            // C# Legeacy
            object IEnumerator.Current
            {
                get { return Current; }
            }
    
            #endregion
        }
    
        // THIS IS THE PLINQ Paritioner
        public class InterlacePartitioner : Partitioner<int>
        {
                int ImageHeight = 0;
                ImageInterlace imageinterlace;
    
                public InterlacePartitioner(int imageHeight)
                {
                    ImageHeight = imageHeight;
                    imageinterlace = new ImageInterlace(ImageHeight);
                }
    
            public override IList<IEnumerator<int>> GetPartitions(int partitionCount)
            {
                int i = 0;
    
                List<List<int>> partz = new List<List<int>>();
    
                foreach (var yline in imageinterlace)
                {
                    partz[i % partitionCount].Add(yline);
                    i++;
                }
                return (IList<IEnumerator<int>>)partz;
            }
     
                public override IEnumerable<int> GetDynamicPartitions()
                {
                    return imageinterlace;
                }
    
                // Consumable from Parallel.ForEach.
                public override bool SupportsDynamicPartitions
                {
                    get
                    {
                        return true;
                    }
                }
        } //end of class
    }
