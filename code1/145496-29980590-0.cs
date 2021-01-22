            IEnumerable<string> lines = new List<string>
            {
                string.Format("{{ line with formatting... {0} }}", id),
                "line 2",
                "line 3"
            };
            StringBuilder sb = new StringBuilder();
            lines.Select(line => sb.AppendLine(line));
            string aString = sb.ToString();
