    internal ImageCodecInfo FindEncoder()
    {
        foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
        {
            if (info.FormatID.Equals(this.guid))
            {
                return info;
            }
        }
        return null;
    }
