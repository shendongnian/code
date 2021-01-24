        public IEnumerable<byte[]> Chunks
        {
            get
            {
                for (var i = 0; i < _chunks.Count - 1; i++)
                {
                    yield return _chunks[i];
                }
                var last = new byte[_lastChunkPos];
                Buffer.BlockCopy(_chunks[_chunks.Count - 1], 0, last, 0, _lastChunkPos);
                yield return last;
            }
        } 
