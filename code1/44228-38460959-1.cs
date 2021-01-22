        public static IEnumerable<int> GetCodePoints(this string s) {
	        var utf32 = new UTF32Encoding(!BitConverter.IsLittleEndian, false, true);
	        var bytes = utf32.GetBytes(s);
	        return Enumerable.Range(0, bytes.Length / 4).Select(i => BitConverter.ToInt32(bytes, i * 4));
        }
