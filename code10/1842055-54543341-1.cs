    try
    {
        using(var br = new BinaryReader(File.OpenRead(element.FileName)))
        {
            while(br.BaseStream.Position != br.Basestream.Length)
            {        
                if(br.ReadInt32() == key1)
                {/*do your other stuff*/}
            }
        }
    }
    catch(Exception ex)
    {
    }
