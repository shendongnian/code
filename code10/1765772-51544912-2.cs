    string payload = Path.GetTempFileName();
    using (FileStream temp_fs = new FileStream(payload, FileMode.OpenOrCreate))
    {
        using (BinaryWriter output_s = new BinaryWriter(new FileStream("target.out", FileMode.OpenOrCreate)))
        {
            //Write a blank. must be a long!
            output_s.Write((long)0);
            foreach (string file in Files)
            {
                //Write the files name
                output_s.Write(file);
                long start = temp_fs.Position;
                //Write the starting point
                output_s.Write(start);
                //Compress the file to the payload
                using (GZipStream gzip = new GZipStream(temp_fs, CompressionMode.Compress, true))
                {
                    using (FileStream fs = new FileStream(file, FileMode.Open))
                    {
                        fs.CopyTo(gzip);
                    }
                }
                //Write the length
                output_s.Write(temp_fs.Position - start);
            }
            //When all files are written
            //Get the size of our header
            long headersize = output_s.BaseStream.Length - 8;
            //Copy the temp file data to the end
            temp_fs.CopyTo(output_s.BaseStream);
            //Reset to the start of the stream
            output_s.BaseStream.Position = 0;
            //override our zero
            output_s.Write(headersize);
        }
    }
    File.Delete(payload);
