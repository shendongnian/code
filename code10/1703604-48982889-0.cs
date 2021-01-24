        internal void Load(Stream stream)
        {
            using(var decoder = new BitmapDecoder(Factory, stream, DecodeOptions.CacheOnLoad))
                Decode(decoder);
        }
        internal void Load(string fn)
        {
            using (var decoder =
                new BitmapDecoder(Factory, fn, NativeFileAccess.Read, DecodeOptions.CacheOnLoad))
                Decode(decoder);
        }
