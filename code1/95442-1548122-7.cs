    class DatabaseFile : IDisposable
    {
        private FileStream file;
        private static int RecordSize = 7;
        private static byte[] Deleted = new byte[] { 42 };
        private static byte[] Undeleted = new byte[] { 32 };
        public DatabaseFile(string filename)
        {
            file = new FileStream(filename, 
                FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
        }
        public IEnumerable<Record> Locate(Predicate<Record> record)
        {
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                long offset = file.Position;
                byte[] buffer = new byte[DatabaseFile.RecordSize];
                file.Read(buffer, 0, DatabaseFile.RecordSize);
                Record current = Read(offset, buffer);
                if (record.Invoke(current))
                    yield return current;
            }
        }
        public void Append(Record record)
        {
            // should I look for duplicated values? i dunno
            file.Seek(0, SeekOrigin.End);
            record.Deleted = false;
            record.Offset = file.Position;
            Write(record);
        }
        public void Delete(Record record)
        {
            if (record.Offset == -1) return;
            file.Seek(record.Offset, SeekOrigin.Begin);
            record.Deleted = true;
            Write(record);
        }
        public void Update(Record record)
        {
            if (record.Offset == -1)
            {
                Append(record);
            }
            else
            {
                file.Seek(record.Offset, SeekOrigin.Begin);
                Write(record);
            }
        }
        private Record Read(long offset, byte[] data)
        {
            byte[] ipAddress = new byte[4];
            Array.Copy(data, 1, ipAddress, 0, ipAddress.Length);
            return new Record
            {
                Offset = offset,
                Deleted = (data[0] == DatabaseFile.Deleted[0]),
                Address = new IPAddress(ipAddress), 
                Port = BitConverter.ToInt16(data, 5)
            };
        }
        private void Write(Record record)
        {
            file.Write(GetBytes(record), 0, DatabaseFile.RecordSize);
        }
        private byte[] GetBytes(Record record)
        {
            byte[] returnValue = new byte[DatabaseFile.RecordSize];
            Array.Copy(
                record.Deleted ? DatabaseFile.Deleted : DatabaseFile.Undeleted, 0, 
                returnValue, 0, 1);
            Array.Copy(record.Address.GetAddressBytes(), 0, 
                returnValue, 1, 4);
            Array.Copy(BitConverter.GetBytes(record.Port), 0, 
                returnValue, 5, 2);
            return returnValue;
        }
        public void Pack()
        {
            long freeBytes = 0;
            byte[] buffer = new byte[RecordSize];
            Queue<long> deletes = new Queue<long>();
            file.Seek(0, SeekOrigin.Begin);
            while (file.Position < file.Length)
            {
                long offset = file.Position;
                file.Read(buffer, 0, RecordSize);
                if (buffer[0] == Deleted[0])
                {
                    deletes.Enqueue(offset);
                    freeBytes += RecordSize;
                }
                else
                {
                    if (deletes.Count > 0)
                    {
                        deletes.Enqueue(offset);
                        file.Seek(deletes.Dequeue(), SeekOrigin.Begin);
                        file.Write(buffer, 0, RecordSize);
                        file.Seek(offset + RecordSize, SeekOrigin.Begin);
                    }
                }
            }
            file.SetLength(file.Length - freeBytes);
        }
        public void Sort()
        {
            int offset = -RecordSize; // lazy method
            List<Record> records = this.Locate(r => true).ToList();
            records.Sort(new RecordComparer());
            foreach (Record record in records)
            {
                record.Offset = offset += RecordSize;
                Update(record);
            }
        }
        public void Dispose()
        {
            if (file != null)
                file.Close();
        }
    }
