    Encoding _big5=Encoding.GetEncoding(950);
    byte[] _buffer=new byte[90];
    public string GetField(FileStream stream,int offset, int length)
    {
        var read=stream.ReadBytes(_buffer,offset,length);
        if(read>0)
        {
            return _big5.GetString(buffer,0,read);
        }
        else 
        {
            return "";
        }
    }
    //Quick & dirty way to skip to end
    public void SkipToLineEnd(FileStream stream)
    {
        int c;
        while((in=stream.ReadByte()>-1)
        {
            if (c==(int)'\n')
            {
                return;
            }
        }
    }
