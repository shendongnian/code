    using Amazon.S3;
    using log4net;
    using NUnit.Framework;
    using System.Runtime.Remoting.Messaging;
    class Sandbox
    {
        [Test]
        public void s()
        {
            LogicalThreadContext.Properties["a"] = "b";
            CallContext.FreeNamedDataSlot("log4net.Util.LogicalThreadContextProperties");
            AmazonS3Client client = new AmazonS3Client("a", "b");
        }
    }
