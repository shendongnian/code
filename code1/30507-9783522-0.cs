    public static ushort GetPEArchitecture(string pFilePath)
    {
        ushort architecture = 0;
        try
        {
            using (System.IO.FileStream fStream = new System.IO.FileStream(pFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (System.IO.BinaryReader bReader = new System.IO.BinaryReader(fStream))
                {
                    if (bReader.ReadUInt16() == 23117) //check the MZ signature
                    {
                        fStream.Seek(0x3A, System.IO.SeekOrigin.Current); //seek to e_lfanew.
                        fStream.Seek(bReader.ReadUInt32(), System.IO.SeekOrigin.Begin); //seek to the start of the NT header.
                        if (bReader.ReadUInt32() == 17744) //check the PE\0\0 signature.
                        {
                            fStream.Seek(20, System.IO.SeekOrigin.Current); //seek past the file header,
                            architecture = bReader.ReadUInt16(); //read the magic number of the optional header.
                        }
                    }
                }
            }
        }
        catch (Exception) { /* TODO: Any exception handling you want to do, personally I just take 0 as a sign of failure */}
        //if architecture returns 0, there has been an error.
        return architecture;
    
