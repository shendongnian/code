    if (packet.Take(3).SequenceEqual(STARTCODE) &&
        packet.Skip(packet.Length - ENDCODE.Length).SequenceEqual(ENDCODE))
    {
        ushort id = BitConverter.ToUInt16(packet, 3);
        ushort semistable = BitConverter.ToUInt16(packet, 5);
        byte contant = packet[7];
        for(int i = 8; i < 72; i += 2)
        {
            il.Add(BitConverter.ToUInt16(packet, i));
        }
        
        foreach(ushort element in il)
        {
            sw.WriteLine(string.Format("{0},{1},{2},{3}", id, semistable, constant, element);
        }
        il.Clear();
    }
    else
    {
        //handle "bad" packets
    }
