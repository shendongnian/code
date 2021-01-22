     using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    
    namespace PipedInfo
    {
        class Program
        {
            static void Main(string[] args)
            {
                StreamReader buffer = ReadPipedInfo();
    
                Console.WriteLine(buffer.ReadToEnd());
            }
    
            #region ReadPipedInfo
            public static StreamReader ReadPipedInfo()
            {
                //call with a default value of 5 milliseconds
                return ReadPipedInfo(5);
            }
    
            public static StreamReader ReadPipedInfo(int waitTimeInMilliseconds)
            {
                //allocate the class we're going to callback to
                ReadPipedInfoCallback callbackClass = new ReadPipedInfoCallback();
    
                //to indicate read complete or timeout
                AutoResetEvent readCompleteEvent = new AutoResetEvent(false);
    
                //open the StdIn so that we can read against it asynchronously
                Stream stdIn = Console.OpenStandardInput();
    
                //allocate a one-byte buffer, we're going to read off the stream one byte at a time
                byte[] singleByteBuffer = new byte[1];
    
                //allocate a list of an arbitary size to store the read bytes
                List<byte> byteStorage = new List<byte>(4096);
    
                IAsyncResult asyncRead = null;
                int readLength = 0; //the bytes we have successfully read
    
                do
                {
                    //perform the read and wait until it finishes, unless it's already finished
                    asyncRead = stdIn.BeginRead(singleByteBuffer, 0, singleByteBuffer.Length, new AsyncCallback(callbackClass.ReadCallback), readCompleteEvent);
                    if (!asyncRead.CompletedSynchronously)
                        readCompleteEvent.WaitOne(waitTimeInMilliseconds);
    
                    //end the async call, one way or another
    
                    //if our read succeeded we store the byte we read
                    if (asyncRead.IsCompleted)
                    {
                        readLength = stdIn.EndRead(asyncRead);
                        if (readLength > 0)
                            byteStorage.Add(singleByteBuffer[0]);
                    }
    
                } while (asyncRead.IsCompleted && readLength > 0);
                //we keep reading until we fail or read nothing
    
                //return results, if we read zero bytes the buffer will return empty
                return new StreamReader(new MemoryStream(byteStorage.ToArray(), 0, byteStorage.Count));
            }
    
            private class ReadPipedInfoCallback
            {
                public void ReadCallback(IAsyncResult asyncResult)
                {
                    //pull the user-defined variable and strobe the event, the read finished successfully
                    AutoResetEvent readCompleteEvent = asyncResult.AsyncState as AutoResetEvent;
                    readCompleteEvent.Set();
                }
            }
            #endregion ReadPipedInfo
        }
    }
