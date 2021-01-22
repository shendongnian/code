    using System.Collections.Generic;
    using System.Threading;
    namespace ThreadSafeQueue {
        public class ThreadSafeQueue<T> {
            private Queue<T> _queue;
    
            public ThreadSafeQueue() {
                _queue = new Queue<T>();
            }
    
            public void EnqueueSafe(T item) {
                lock ( this ) {
                    _queue.Enqueue(item);
                    if ( _queue.Count >= 1 )
                        Monitor.Pulse(this);
                }
            }
    
            public T DequeueSafe() {
                lock ( this ) {
                    while ( _queue.Count <= 0 )
                        Monitor.Wait(this);
    
                    return this.DeEnqueueUnblock();
    
                }
            }
    
            private T DeEnqueueUnblock() {
                return _queue.Dequeue();
            }
        }
    }
