    var codecFilter;
    var codecs = ImageCodecInfo.GetImageEncoders();
    var sep = "";
    foreach (var codec in codecs)
    {    
        var codecName = codec.CodecName.Substring(8).Replace("Codec", "Files").Trim();
        codecFilter = System.String.Format("{0}{1}{2} ({3})|{3}", codecFilter, sep, codecName, codec.FilenameExtension);
        sep = "|";
    }
    dialog.Filter = codecFilter;
