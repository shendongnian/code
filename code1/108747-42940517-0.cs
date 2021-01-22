    fileBytes = new byte[theLength * 4]; // * 4 bytes per element for int and float
    var offset =0;
        foreach (var element in outputDimensions)
        {
            // fastCopy is a faster and "Unsafe" equivelent of BlockCopy , faster because it doesn't create an intermediate byte array.
            //Buffer.BlockCopy(BitConverter.GetBytes(profileid), 0, fileBytes, offset, 4);
            Utilities.fastCopy(profileid, fileBytes, offset);
            offset += 4;
            Utilities.fastCopy(element.index, fileBytes, offset);
            offset += 4;
            for (var i = 0; i < TimeSlices; i++, offset += 4)
            {
                float target = GetDataForTime(i,...);
                Utilities.fastCopy(target, fileBytes, offset); 
            }
        }
    FileStream dataWriter.Write(fileBytes , 0, byteArray.Length);
