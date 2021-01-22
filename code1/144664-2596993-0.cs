    class SqlXmlReader : XmlReader
    {
        private SqlConnection connection;
        private XmlReader reader;
        public SqlXmlReader(SqlCommand cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException("cmd");
            this.connection = cmd.Connection;
            this.reader = cmd.ExecuteXmlReader();
        }
        public override void Close()
        {
            reader.Close();
            connection.Close();
        }
    }
