        public static Image LoadImageNoLock(string path) {
            using (var ms = new MemoryStream(File.ReadAllBytes(path))) {
                return Image.FromStream(ms);
            }
        }
