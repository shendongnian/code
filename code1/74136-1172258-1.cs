        public static string GetTextAfterMarker(string line, string marker)
        {
            int pos = line.LastIndexOf(marker);
            if (pos < 0)
                return string.Empty;
            else
                return line.Substring(pos + marker.Length);
        }
