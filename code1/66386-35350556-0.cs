    private void LosslessJpegTest() {
      var original = "d:\\!test\\TestInTest\\20150205_123011.jpg";
      var copy = original;
      const BitmapCreateOptions createOptions = BitmapCreateOptions.PreservePixelFormat | BitmapCreateOptions.IgnoreColorProfile;
      for (int i = 0; i < 100; i++) {
        using (Stream originalFileStream = File.Open(copy, FileMode.Open, FileAccess.Read)) {
          BitmapDecoder decoder = BitmapDecoder.Create(originalFileStream, createOptions, BitmapCacheOption.None);
          if (decoder.CodecInfo == null || !decoder.CodecInfo.FileExtensions.Contains("jpg") || decoder.Frames[0] == null)
            continue;
          BitmapMetadata metadata = decoder.Frames[0].Metadata == null
            ? new BitmapMetadata("jpg")
            : decoder.Frames[0].Metadata.Clone() as BitmapMetadata;
          if (metadata == null) continue;
          var keywords = metadata.Keywords == null ? new List<string>() : new List<string>(metadata.Keywords);
          keywords.Add($"Keyword {i:000}");
          metadata.Keywords = new ReadOnlyCollection<string>(keywords);
          JpegBitmapEncoder encoder = new JpegBitmapEncoder {QualityLevel = 80};
          encoder.Frames.Add(BitmapFrame.Create(decoder.Frames[0], decoder.Frames[0].Thumbnail, metadata,
            decoder.Frames[0].ColorContexts));
          copy = original.Replace(".", $"_{i:000}.");
          using (Stream newFileStream = File.Open(copy, FileMode.Create, FileAccess.ReadWrite)) {
            encoder.Save(newFileStream);
          }
        }
      }
    }
