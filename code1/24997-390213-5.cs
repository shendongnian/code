        [Serializable]
        public class MyException : Exception, ISerializable
        {
            public int ErrorCode = 10;
            public MyException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
                ErrorCode = info.GetInt32("ErrorCode");
            }
            public MyException(string message)
                : base(message)
            {
            }
            #region ISerializable Members
            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
                info.AddValue("ErrorCode", ErrorCode);
            }
            #endregion
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
            Text = ex2.ErrorCode.ToString(); // form shows 20
            // throw ex2;
        }
