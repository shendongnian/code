    using (BinaryReader reader = new BinaryReader(File.Open(element.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
    {
        int position = 0;
        while (position < (reader.BaseStream.Length - 4))
        {
            reader.BaseStream.Position = position;
            if (reader.ReadInt32() == -1466731422)
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(element.FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite)))
                {
                    writer.BaseStream.Position = position;
                    writer.Write(-1566731422);
                }
                break;
            }
            position += 1;
        }
    }
