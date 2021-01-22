    /// <summary>
    /// A basic thread-safe multiple producer, multiple consumer queue.
    /// Items can be consumed with <c>foreach<c>.
    /// </summary>
    /// <typeparam name="T">Type of items in the queue.</typeparam>
    public class SignaledQueue<T>
    {
        Queue<T> queue = new Queue<T>();
        object syncRoot = new object();
        object signal = new object();
        volatile bool shutDown = false;
        /// <summary>
        /// Enqueues an item. 
        /// </summary>
        /// <param name="item">The item to enqueue.</param>
        /// <returns>A return value of <c>false</c> indicates that processing should stop.</returns>
        public bool Enqueue(T item)
        {
            if (!shutDown)
            {
                lock (syncRoot)
                {
                    queue.Enqueue(item);
                    //Lock for the signal is taken inside the main lock,
                    //to avoid losing it in Dequeue().
                    lock (signal)
                    {
                        //We have only one new workitem.
                        //No need to wake up more than one worker with PulseAll().
                        Monitor.Pulse(signal);
                    }
                }
                return true;
            }
            //Indicate that processing should stop.
            return false;
        }
        /// <summary>
        /// Dequeues items from the queue. Blocks if there are no items to process.
        /// </summary>
        /// <remarks>Stops if it is requested by <seealso cref="SignalShutDown()"/></remarks>
        /// <returns>Returns items from the queue.</returns>
        public IEnumerable<T> DequeueAll()
        {
            //Just flee and leave the work as is if we are shut down.
            while (!shutDown)
            {
                bool signalOwned = false;
                try
                {
                    do
                    {
                        T item;
                        //Only lock for the duration of a single dequeue operation.
                        //Processing will be done outside of the lock.
                        lock (syncRoot)
                        {
                            //If the queue is empty, wait for the wake-up signal.
                            if (queue.Count == 0)
                            {
                                //Take ownership of the signal inside the main lock,
                                //to avoid race condition.
                                //signalOwned will always be true after this call,
                                //except if there is an exception.
                                signalOwned = Monitor.TryEnter(signal, -1);
                                break;
                            }
                            item = queue.Dequeue();
                            //Leave the lock as soon as possible.
                        }
                        //No locks are held at this point.
                        //We can safely yield control back.
                        yield return item;
                    } while (!shutDown);
                    //signalOwned is true only if we should wait.
                    if (signalOwned)
                    {
                        Monitor.Wait(signal);
                    }
                }
                finally
                {
                    //If signal is locked, unlock it.
                    if (signalOwned)
                    {
                        Monitor.Exit(signal);
                    }
                }
            }
        }
        /// <summary>
        /// Signals that no more operations are allowed.
        /// </summary>
        /// <remarks>
        /// This method only signals that processing should stop. 
        /// It returns immediately.
        /// </remarks>
        public void SignalShutDown()
        {
            shutDown = true;
            lock (syncRoot)
            {
                lock (signal)
                {
                    //Signal all waiting threads with PulseAll().
                    Monitor.PulseAll(signal);
                }
            }
        }
    }
