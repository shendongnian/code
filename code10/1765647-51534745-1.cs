    // input data
    string inputName = "input.bin";
    long startInput = 0xa0;
    long endInput = 0xb0; // excluding 0xb0 that is not copied
    string outputName = "output.bin";
    long startOutput = 0xa0;
    // begin of code
    long count = endInput - startInput;
    using (var fs = File.OpenRead(inputName))
    using (var fs2 = File.OpenWrite(outputName))
    {
        fs.Seek(startInput, SeekOrigin.Begin);
        fs2.Seek(startOutput, SeekOrigin.Begin);
        byte[] buf = new byte[4096];
        while (count > 0)
        {
            int read = fs.Read(buf, 0, (int)Math.Min(buf.Length, count));
            if (read == 0)
            {
                // end of file encountered
                throw new IOException("end of file encountered");
            }
            fs2.Write(buf, 0, read);
            count -= read;
        }
    }
