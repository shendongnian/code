    DicomFile ctFile = DicomFile.Open(@"C:\Temp\original.dcm");
    // Create PixelData object to represent pixel data in dataset
    DicomPixelData pixelData = DicomPixelData.Create(ctFile.Dataset);
    // Get Raw Data
    byte[] originalRawBytes = pixelData.GetFrame(0).Data;
    // Create new array with modified data
    byte[] modifiedRawBytes = new byte[originalRawBytes.Length];
    for (int i = 0; i < originalRawBytes.Length; i++)
    {
        modifiedRawBytes[i] = (byte)(originalRawBytes[i] + 100);
    }
    // Create new buffer supporting IByteBuffer to contain the modified data
    MemoryByteBuffer modified = new MemoryByteBuffer(modifiedRawBytes);
    // Write back modified pixel data
    ctFile.Dataset.AddOrUpdatePixelData(DicomVR.OB, modified);
    ctFile.Save(@"C:\Temp\Modified.dcm");
