    void Main()
    {
        using (FileStream stream = new FileStream(@"c:\temp\test.dat", FileMode.Create))
        using (BinaryWriter writer = new BinaryWriter(stream))
            writer.EncodeInt32(123456789);
    
        using (FileStream stream = new FileStream(@"c:\temp\test.dat", FileMode.Open))
        using (BinaryReader reader = new BinaryReader(stream))
            reader.DecodeInt32().Dump();
    }
    
    // Define other methods and classes here
    
    public static class Extensions
    {
        /// <summary>
        /// Encodes the specified <see cref="Int32"/> value with a variable number of
        /// bytes, and writes the encoded bytes to the specified writer.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="BinaryWriter"/> to write the encoded value to.
        /// </param>
        /// <param name="value">
        /// The <see cref="Int32"/> value to encode and write to the <paramref name="writer"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <para><paramref name="writer"/> is <c>null</c>.</para>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para><paramref name="value"/> is less than 0.</para>
        /// </exception>
        /// <remarks>
        /// See <see cref="DecodeInt32"/> for how to decode the value back from
        /// a <see cref="BinaryReader"/>.
        /// </remarks>
        public static void EncodeInt32(this BinaryWriter writer, int value)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            if (value < 0)
                throw new ArgumentOutOfRangeException("value", value, "value must be 0 or greater");
                
            bool first = true;
            while (first || value > 0)
            {
                first = false;
                byte lower7bits = (byte)(value & 0x7f);
                value >>= 7;
                if (value > 0)
                    lower7bits |= 128;
                writer.Write(lower7bits);
            }
        }
    
        /// <summary>
        /// Decodes a <see cref="Int32"/> value from a variable number of
        /// bytes, originally encoded with <see cref="EncodeInt32"/> from the specified reader.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="BinaryReader"/> to read the encoded value from.
        /// </param>
        /// <returns>
        /// The decoded <see cref="Int32"/> value.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <para><paramref name="reader"/> is <c>null</c>.</para>
        /// </exception>
        public static int DecodeInt32(this BinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
                
            bool more = true;
            int value = 0;
            int shift = 0;
            while (more)
            {
                byte lower7bits = reader.ReadByte();
                more = (lower7bits & 128) != 0;
                value |= (lower7bits & 0x7f) << shift;
                shift += 7;
            }
            return value;
        }
    }
