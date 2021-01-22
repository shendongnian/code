    public IEnumerator<object[]> GetEnumerator()
    {
                    
        while (true)
        {
            List<object[]> chunk = new List<object[]>(_ChunkSize);
            _ChunkPos = 0;
            lock(_Input)
            {
                for (int i = 0; i < _ChunkSize; ++i)
                {
                    if (!_Input.Read())
                        break;
                    var values = new object[_Input.FieldCount];
                    _Input.GetValues(values);
                    chunk.Add(values);
                }
                if (chunk.Count == 0)
                    yield break;
            }
            var chunkEnumerator = chunk.GetEnumerator();
            while (true)
            {
                object[] retVal;
                lock (_ChunkLock)
                {
                    if (chunkEnumerator.MoveNext())
                    {
                        retVal = chunkEnumerator.Current;
                    }
                    else 
                        break; //break out of chunk while loop.
                }
                yield return retVal;
            }
        }
    }
