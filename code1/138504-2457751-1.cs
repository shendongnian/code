    using(var reader = new MySqlBatchReader(new StreamReader(dmlFile))) {
        string batch;
        while((batch = reader.ReadBatch()) != null) {
            var cmd = new SqlCommand(batch, conn, trans) { CommandType = CommandType.Text };
            cmd.ExecuteNonQuery();
        }
    }
    class MySqlBatchReader : IDisposable {
        private TextReader _reader;
        public MySqlBatchReader(TextReader reader) {
            _reader = reader;
        }
        // Return the next command batch in the file, or null if end-of-file reached.
        public string ReadBatch() {
            // TODO
        }
    }
