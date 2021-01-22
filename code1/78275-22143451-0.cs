        public static string BytesToString(this long bytes) {
            var prefix = new string[] { "B", "KB", "MB", "GB", "TB" };
            var bytesd = Convert.ToDouble(bytes);
            var unit = 0;
            while (bytesd / 1024D > 1 && unit < prefix.Length) {
                unit++; bytesd /= 1024D;
            }
            return string.Format("{0:#,##0.00}{1}", bytesd, prefix[unit]);
        }
