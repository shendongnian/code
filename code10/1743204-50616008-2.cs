    public byte[] ConvertToMp3(Uri uri)
    {
       using (var client = new WebClient())
       {
          var file = client.DownloadData(uri);
          var target = new WaveFormat(8000, 16, 1);
          using (var outPutStream = new MemoryStream())
          using (var waveStream = new WaveFileReader(new MemoryStream(file)))
          using (var conversionStream = new WaveFormatConversionStream(target, waveStream))
          using (var writer = new LameMP3FileWriter(outPutStream, conversionStream.WaveFormat, 32, null))
          {
             conversionStream.CopyTo(writer);
    
             return outPutStream.ToArray();
          }
       }
    }
