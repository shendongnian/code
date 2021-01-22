        public byte[] ToBytes(byte[] bytes, ref int index)
        {
            // Convert Number
            Buffer.BlockCopy(BitConverter.GetBytes(Number), 0, bytes, index, 4);;
            index += 4;
            // Convert Partials
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)(Partials == null ? 0 : Partials.Length)), 0, bytes, index, 2);
            index += 2;
            foreach(var value in Partials ?? Enumerable.Empty<Partial>())
            {
            	value.ToBytes(bytes, ref index);
            }
            // Convert Numbers
            // Two bytes length information for each dimension
            Buffer.BlockCopy(BitConverter.GetBytes((ushort)(Numbers == null ? 0 : Numbers.Count)), 0, bytes, index, 2);
            index += 2;
            foreach(var value in Numbers ?? Enumerable.Empty<ulong>())
            {
            	Buffer.BlockCopy(BitConverter.GetBytes(value), 0, bytes, index, 8);;
            	index += 8;
            }
            return bytes;
        }
