    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
    dlgOpenMockImage.Filter = string.Format("{0}| All image files ({1})|{1}|All files|*", 
        string.Join("|", codecs.Select(codec => 
        string.Format("{0} ({1})|{1}", codec.CodecName, codec.FilenameExtension)).ToArray()),
        string.Join(";", codecs.Select(codec => codec.FilenameExtension).ToArray()));
