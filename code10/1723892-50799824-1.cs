        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            IList<ClassificationSpan> list = new List<ClassificationSpan>();
            ITextSnapshotLine line = span.Start.GetContainingLine();
            string text = line.GetText();
            foreach (var tuple in _map)
            {
                AddMatchingHighlighting(tuple.Item1, text, line, list, tuple.Item2);
            }
            string fullFileText = span.Snapshot.GetText();
            var contracts = Regex.Matches(fullFileText, @"(?:contract|struct|enum)\W+([\w_]+)", RegexOptions.Compiled).Cast<Match>().Select(x => x.Groups[1].Value);
            var matchingItems = new Regex($@"\b({string.Join("|", contracts)})\b");
            AddMatchingHighlighting(matchingItems, text, line, list, _typeClassification);
            return list;
        }
        private static void AddMatchingHighlighting(Regex regex, string text, ITextSnapshotLine line, ICollection<ClassificationSpan> list, IClassificationType classificationType)
        {
            foreach (Match match in regex.Matches(text))
            {
                var str = new SnapshotSpan(line.Snapshot, line.Start.Position + match.Index, match.Length);
                if (list.Any(s => s.Span.IntersectsWith(str)))
                    continue;
                list.Add(new ClassificationSpan(str, classificationType));
            }
        }
