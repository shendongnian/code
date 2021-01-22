    using SevenZip.Compression.LZMA;
    private static void CompressFileLZMA(string inFile, string outFile)
    {
       SevenZip.Compression.LZMA.Encoder coder = new SevenZip.Compression.LZMA.Encoder();
        
       using (FileStream input = new FileStream(inFile, FileMode.Open))
       {
          using (FileStream output = new FileStream(outFile, FileMode.Create))
          {
              coder.Code(input, output, -1, -1, null);
              output.Flush();
          }
       }
    }
