            IEnumerable<string> lines = new List<string>
            {
                string.Format("{{ line with formatting... {0} }}", id),
                "line 2",
                "line 3"
            };
            StringBuilder sb = new StringBuilder();
            foreach(var line in lines)
                sb.AppendLine(line);
