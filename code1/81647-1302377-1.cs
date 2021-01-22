    /// <summary>
    /// Provides concurrent processing on a sequence of elements
    /// </summary>
    public static class Parallel
    {
        /// <summary>
        /// Number Of parallel tasks 
        /// </summary>
        public static int NumberOfParallelTasks;
       
        
        static Parallel()
        {
            NumberOfParallelTasks =  Environment.ProcessorCount < 65 ?  Environment.ProcessorCount : 64;  
        }
        /// <summary>
        /// Performs the specified action on each element of the sequence in seperate threads.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence that contains elements to perform action</param>
        /// <param name="action">The Action delegate to perform on each element of the IEnumerable.</param>
        public static void ForEach<T>( IEnumerable<T> source, Action<T> action )
        {
            if(source == null) return;
            
            //create a new stack for parallel task we want to run  , stack is very performant to add and read elements in sequence
            var stacks = new Stack<T>[NumberOfParallelTasks]; 
            //instantiate stacks
            for(var i = 0;i < NumberOfParallelTasks;i++)
            {
                stacks[i] = new Stack<T>();
            }
            var itemCount = 0;
            //spread items in source to all stacks while alternating between stacks
            foreach(var item in source)
            {
                stacks[itemCount++ % NumberOfParallelTasks].Push(item);
            }
            
            if(itemCount==0)return;
            //if we have less items than number of Parallel tasks we should only spun threads for active stacks
            var activeStackCount = itemCount < NumberOfParallelTasks ? itemCount : NumberOfParallelTasks;
            //events are used to notify thread pool completed
            var events = new ManualResetEvent[activeStackCount];
       
            for(var index = 0;index < activeStackCount;index++)
            {
                //assign index to a scope variable otherwise in multithreading index will not be consistant
                var listIndex = index;
                
                events[listIndex] = new ManualResetEvent(false); 
                
                ThreadPool.QueueUserWorkItem(delegate
                {
                    //name the thread for debugging
                    if(String.IsNullOrEmpty(Thread.CurrentThread.Name))
                    {
                        Thread.CurrentThread.Name = String.Format("Parallel.ForEach Worker Thread No:{0}", listIndex);
                    }
                    
                    try
                    {   
                        //iterate through our stack 
                        var stack = stacks[listIndex];
                        foreach(var item in stack)
                        {
                            action(item); 
                        }   
                    }
                    finally
                    {
                        //fire the event to signal WaitHandle that our thread is completed
                        events[listIndex].Set();
                    }
                });
            }
            WaitAll(events);
              
        }
        private static void WaitAll(WaitHandle[] waitHandles)
        {
            if(Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
            {
                for(var index = 0;index < waitHandles.Length;index++) WaitHandle.WaitAny(waitHandles);
            }
            else
            {
                WaitHandle.WaitAll(waitHandles); 
            }
        }
        /// <summary>
        /// Performs the specified action on each element of the sequence in seperate threads.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="source">A sequence that contains elements to perform action</param>
        /// <param name="action">The Action delegate to perform on each element of the IEnumerable.</param>
        public static void  ParallelForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            ForEach(source, action);
        }
      
    }
