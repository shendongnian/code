    int valOriginal = -1466731422;
    int valSubstitute = -1566731422;
    int valLength = BitConverter.GetBytes(valOriginal).Length;
    using (var reader = new BinaryReader(
        File.Open("[File Path]", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))) {
        int position = 0;
        while (position < (reader.BaseStream.Length - valLength))
        {
            reader.BaseStream.Position = position;
            if (reader.ReadInt32() == valOriginal)
            {
                using (var writer = new BinaryWriter(
                    File.Open("[File Path]", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))) {
                    writer.BaseStream.Position = position;
                    writer.Write(valSubstitute);
                };
                break;
            }
            position += 1;
        }
    };
