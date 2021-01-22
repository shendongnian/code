public void ReadFile(string filename)
{
    using (FileStream fs = File.OpenRead(filename))
    {
        fs.Seek(128, SeekOrigin.Begin);
        if ((fs.ReadByte() != (byte)'D' ||
             fs.ReadByte() != (byte)'I' ||
             fs.ReadByte() != (byte)'C' ||
             fs.ReadByte() != (byte)'M'))
        {
            Console.WriteLine("Not a DCM");
            return;
        }
        BinaryReader reader = new BinaryReader(fs);
        ushort g;
        ushort e;
        do
        {
            g = reader.ReadUInt16();
            e = reader.ReadUInt16();
            string vr = new string(reader.ReadChars(2));
            long length;
            if (vr.Equals("AE") || vr.Equals("AS") || vr.Equals("AT")
                || vr.Equals("CS") || vr.Equals("DA") || vr.Equals("DS")
                || vr.Equals("DT") || vr.Equals("FL") || vr.Equals("FD")
                || vr.Equals("IS") || vr.Equals("LO") || vr.Equals("PN")
                || vr.Equals("SH") || vr.Equals("SL") || vr.Equals("SS")
                || vr.Equals("ST") || vr.Equals("TM") || vr.Equals("UI")
                || vr.Equals("UL") || vr.Equals("US"))
               length = reader.ReadUInt16();
            else
            {
                // Read the reserved byte
                reader.ReadUInt16();
                length = reader.ReadUInt32();
            }
            byte[] val = reader.ReadBytes((int) length);
        } while (g == 2);
        fs.Close();
    }
    return ;
}
