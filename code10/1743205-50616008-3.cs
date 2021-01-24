    public async Task<byte[]> ConvertToMp3Async(Uri uri)
    {
       using (var client = new WebClient())
       {
          var file = await client.DownloadDataTaskAsync(uri);
          var target = new WaveFormat(8000, 16, 1);
          using (var outPutStream = new MemoryStream())
          using (var waveStream = new WaveFileReader(new MemoryStream(file)))
          using (var conversionStream = new WaveFormatConversionStream(target, waveStream))
          using (var writer = new LameMP3FileWriter(outPutStream, conversionStream.WaveFormat, 32, null))
          {
              await conversionStream.CopyToAsync(writer);
    
              return outPutStream.ToArray();
          }
       }
    }
