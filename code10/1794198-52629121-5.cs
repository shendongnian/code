    public IEnumerable<System.IO.Stream> ImageProcessing(System.IO.Stream input)
    {
        using(Bitmap inputAsBitmap = new Bitmap(input))
        {
            // --- Applying miscellaneous filters ---
    
            foreach(var subPart in GetSubParts(inputAsBitmap))
            {
                MemoryStream memoryStream = new MemoryStream();
    
                using(subPart)
                {
                    subPart.Save(memoryStream, ImageFormat.Jpeg);
                }
    
                yield return memoryStream;
            }
        }
    }
