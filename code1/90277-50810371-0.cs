    public static IEnumerable<string> Split(this string str, int chunkSize)
        {
            if(string.IsNullOrEmpty(str) || chunkSize<1)
                throw new ArgumentException("String can not be null or empty and chunk size should be greater than zero.");
            var chunkCount = str.Length / chunkSize + (str.Length % chunkSize != 0 ? 1 : 0);
            for (var i = 0; i < chunkCount; i++)
            {
                var startIndex = i * chunkSize;
                if (startIndex + chunkSize >= str.Length)
                    yield return str.Substring(startIndex);
                else
                    yield return str.Substring(startIndex, chunkSize);
            }
        }
