    01.using System;
    02.using System.Threading; <=== NOTE THIS
    03.using FileHelpers;
    04.using NUnit.Framework;
    05. 
    06.namespace FileHelpersTests.Tests.Common
    07.{
    08.    [TestFixture]
    09.    public class Multithreading
    10.    {
    11.        private ManualResetEvent flagStart;
    12.        private CountdownEvent flagFinish;
    13.        private Exception initializationException;
    14. 
    15.        [Test]
    16.        public void AsyncEngineInitialization()
    17.        {
    18.            flagStart = new ManualResetEvent(false);
    19.            flagFinish = new CountdownEvent(2); <=== INITIALIZING COUNT
    20. 
    21.            new Thread(InitializeAsyncEngineWhenFlagIsRaised).Start();
    22.            new Thread(InitializeAsyncEngineWhenFlagIsRaised).Start();
    23. 
    24.            flagStart.Set();
    25.            flagFinish.Wait();
    26.             
    27.            if (initializationException != null) throw new ApplicationException("Failure during AsyncEngine initialization", initializationException);
    28.        }
    29. 
    30.        private void InitializeAsyncEngineWhenFlagIsRaised()
    31.        {
    32.            flagStart.WaitOne();
    33.            try
    34.            {
    35.                new FileHelperAsyncEngine<SampleType>();
    36.            }
    37.            catch (Exception e)
    38.            {
    39.                initializationException = e;
    40.            }
    41.            flagFinish.Decrement(); <== WORKER THREADS SIGNAL WHEN DONE
    42.        }
    43. 
    44.    }
    45.}
