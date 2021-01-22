     public void ReceiveAsync<T>(MqReceived<T> mqReceived)
        {
            try
            {
                receiveEventHandler = (source, args) =>
                {
                    var queue = (MessageQueue)source;
                    using (Message msg = queue.EndPeek(args.AsyncResult))
                    {
                        XmlMessageFormatter formatter = new XmlMessageFormatter(new Type[] { typeof(T) });
                        msg.Formatter = formatter;
                        queue.ReceiveById(msg.Id);
                        T tMsg = (T)msg.Body;
                        mqReceived(tMsg);
                    }
                    queue.BeginPeek();
                };
                messageQueu.PeekCompleted += receiveEventHandler;
                messageQueu.BeginPeek();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
