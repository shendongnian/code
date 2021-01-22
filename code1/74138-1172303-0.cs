        public static string GetTextAfterMarker(string line, string marker)
        {
            if (String.IsNullOrEmpty(line))
                throw new ArgumentException("line is null or empty.", "line");
            if (String.IsNullOrEmpty(marker))
                throw new ArgumentException("marker is null or empty.", "marker");
            string EscapedMarker = Regex.Escape(marker);
            return Regex.Match(line, EscapedMarker + "([^" + EscapedMarker + "]+)").Groups[1].Value;
        }
