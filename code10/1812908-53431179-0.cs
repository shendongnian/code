     public static void ConvertMemoryStreamToWavFile(ref MemoryStream ids, ref 
     MemoryStream ms)
        {
            ids.Seek(0, SeekOrigin.Begin);
            
            using (var writer = new WaveFileWriter(new IgnoreDisposeStream(ms), new WaveFormat(22000, 16, 1)))
            {
                ids.CopyTo(writer);
                writer.Flush();
                writer.Close();
                writer.Dispose();
            }
        }
