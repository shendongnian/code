    // A Parallel Progress Manager is designed to collect progress information from multiple sources and provide a total sum of progress.
    // For example, if 3 objects are going to perform some work in parallel, and the first object has 10 tasks, the second has 100, and the last has 1000,
    // when executing in parallel, it isn't useful to have each task fire a ProgressChanged() event (or something similar), as it would result in the progress
    // being returned something like 0/10, 1/10, 2/10, 0/100, 3/10, 1/100, 0/1000, etc. (As each thread executes independently.)
    //
    // Instead, this class aggregates progress and provides a total sum of progress: 0/1110, 1/1110, etc.
    //
    // NOTE: The intention of this class is to manage parallelized workloads across numerous jobs. For example, operating in parallel against 3 different objects
    // that all report progress independently, such as Paralle.ForEach(IEnumerable<T>). This is not suggested for parallelized workloads of a single job, such as
    // Parallel.For(i, 100)—in this case, it is recommended to update progress using Interlocked.Increment() or a lock() on a synchronization object as one would normally.
    
    // Example:
    //
    // ParallelProgressManager ppm = new ParallelProgressManager();
    //
    // Parallel.ForEach(IEnumerable<T>, t =>
    // {
    //      t.ProgressChanged += delegate (long current, long total, bool indeterminate, string message)
    //      {
    //          lock(ppm)
    //          {
    //              var x = ppm.SetGetProgress(t.GetHashCode(), current, total);
    //
    //              ReportProgress(x.Item1, x.Item2, false, $"Working... {x.Item1} / {x.Item2}");
    //          }
    //      }
    // });
    
    using System;
    using System.Collections.Generic;
    
    namespace Threading
    {
        /// <summary>
        /// A Parallel Progress Manager used to aggregate and sum progress across multiple objects working in parallel.
        /// </summary>
        public class ParallelProgressManager
        {
            /// <summary>
            /// The progress class contains current and total progress and
            /// </summary>
            protected class Progress
            {
                public long Current { get; set; } = 0;
                public long Total { get; set; } = 0;
            }
    
            /// <summary>
            /// The ProgressDictionary associates each working object's Hash Code with it's current progress (via a Progress object.)
            /// This way an object can operate in parallel and as progress updates come in, the last update is replaced by the new one.
            /// We can then sum the "current" and "total" to produce an overall progress value.
            /// </summary>
            private Dictionary<int, Progress> ProgressDictionary { get; set; } = new Dictionary<int, Progress>();
    
            /// <summary>
            /// Sets an object's progress via it's Hash Code. If the object isn't recognized, a new entry will be made for it. If it is recognized,
            /// it's progress will be updated accordingly.
            /// </summary>
            /// <param name="hashCode">
            /// The Hash Code of the object (.GetHashCode()) that's reporting progress. The Hash Code is used to distinguish the objects to manage progress of.
            /// </param>
            /// <param name="current">
            /// The current progress.
            /// </param>
            /// <param name="total">
            /// The total progress.
            /// </param>
            public void SetProgress(int hashCode, long current, long total)
            {
                if (!ProgressDictionary.ContainsKey(hashCode))
                    ProgressDictionary.Add(hashCode, new Progress() { Current = current, Total = total });
                else
                {
                    ProgressDictionary[hashCode].Current = current;
                    ProgressDictionary[hashCode].Total = total;
                }
            }
    
            /// <summary>
            /// Retrieves the total progress of all objects currently being managed.
            /// </summary>
            /// <returns>
            /// A Tuple where the first value represents the summed current progress, and the second value represents the summed total progress.
            /// </returns>
            public Tuple<long, long> GetProgress()
            {
                long c = 0;
                long t = 0;
    
                foreach (var p in ProgressDictionary)
                {
                    c += p.Value.Current;
                    t += p.Value.Total;
                }
    
                return Tuple.Create(c, t);
            }
    
            /// <summary>
            /// Sets progress for the provided object and retrieves an updated total progress. This is equivalent to calling SetProgress() and then calling
            /// GetProgress() immediately after.
            /// </summary>
            /// <param name="hashCode"></param>
            /// <param name="currentStep"></param>
            /// <param name="totalSteps"></param>
            /// <returns></returns>
            public Tuple<long, long> SetGetProgress(int hashCode, long currentStep, long totalSteps)
            {
                SetProgress(hashCode, currentStep, totalSteps);
                return GetProgress();
            }
        }
    }
