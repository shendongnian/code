    IEnumerable<int> GetAllWritableCodepoints(Encoding encoding)
    {
        encoding = Encoding.GetEncoding(encoding.WebName, new EncoderExceptionFallback(), new DecoderExceptionFallback());
        var i = -1;
        // Docs for char.ConvertFromUtf32() say that 0x10ffff is the maximum code point value.
        while (i != 0x10ffff)
        {
            i++;
            var success = false;
            try
            {
                encoding.GetByteCount(char.ConvertFromUtf32(i));
                success = true;
            }
            catch (ArgumentException)
            {
            }
            if (success)
            {
                yield return i;
            }
        }
    }
