    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace MSMQReader
    {
        public class MSMQRead
        {
            public void DoIt()
            {
                var messageQueue = new System.Messaging.MessageQueue(@"FormatName:Direct=OS:<HOST NAME>\Private$\<PRIVATE QUEUE NAME>");
                var message = messageQueue.Receive(new TimeSpan(0, 0, 3)); // 3 SECOND TIMEOUT
                var messageBody = ConvertStreamToByteArray(message.BodyStream);
            }
    
    
            public byte[] ConvertStreamToByteArray(System.IO.Stream input)
            {
                byte[] buffer = new byte[16 * 1024];
    
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    int chunk;
    
                    while ((chunk = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, chunk);
                    }
    
                    return ms.ToArray();
                }
            }
        }
    }
