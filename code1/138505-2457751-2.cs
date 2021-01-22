    using(var reader = new SqlBatchReader(new StreamReader(dmlFile))) {
        string batch;
        while((batch = reader.ReadBatch()) != null) {
            var cmd = new SqlCommand(batch, conn, trans) { CommandType = CommandType.Text };
            cmd.ExecuteNonQuery();
        }
    }
    class SqlBatchReader : IDisposable {
        private TextReader _reader;
        public SqlBatchReader(TextReader reader) {
            _reader = reader;
        }
        /// <summary>
        /// Return the next command batch in the file, or null if end-of-file reached.
        /// </summary>
        public string ReadBatch() {
            // TODO: Implement your parsing logic here.
        }
    }
