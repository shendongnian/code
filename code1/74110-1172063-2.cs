        public static string GetTextBeforeMarker(string line, string marker)
        {
            if (String.IsNullOrEmpty(line))
                throw new ArgumentException("line is null or empty.", "line");
            if (String.IsNullOrEmpty(marker))
                throw new ArgumentException("marker is null or empty.", "marker");
            return Regex.Match(line, "[^" + Regex.Escape(marker) + "]+").Value;
        }
