        /// <summary>
        /// Checks if a (remote) Microsoft Message Queue is available
        /// </summary>
        /// <param name="queueName">The name of the Message Queue.</param>
        /// <returns>Returns true if the queue is available otherwise false.</returns>
        public static bool IsQueueAvailable(string queueName)
        {
            MessageQueue queue;
            try
            {
                queue = new MessageQueue(queueName);
                queue.Peek(new TimeSpan(0, 0, 5)); // wait max. 5 sec. to recieve first message from queue (reduce if necessary)
                return true;
            }
            catch (Exception ex)
            {
                if(ex is ArgumentException)
                {   // the provided queue name is wrong.
                    return false;
                }
                else if (ex is MessageQueueException)
                {   // if message queue exception occurs either the queue is avialable but without entries (check for peek timeout) or the queue does not exist or you don't have access.
                    return (((MessageQueueException)ex).MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout);
                }
                // any other error occurred.
                return false;
            }
        }
