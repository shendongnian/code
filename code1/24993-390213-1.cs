        [SerializableAttribute]
        public class MyException : Exception
        {
            public int ErrorCode = 10;
            public MyException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
            public MyException(string message)
                : base(message)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyException ex = new MyException("Hello, world!");
            ex.ErrorCode = 20;
            WrappedException reply = new WrappedException(ex);
            XmlSerializer x = new XmlSerializer(reply.GetType());
            MemoryStream stream = new MemoryStream();
            x.Serialize(stream, reply);
            stream.Position = 0;
            WrappedException reply2 = (WrappedException)x.Deserialize(stream);
            MyException ex2 = (MyException)reply2.GetException();
            stream.Close();
            Text = ex.ErrorCode.ToString(); // form shows 20 as expected
            // throw ex2;
        }
