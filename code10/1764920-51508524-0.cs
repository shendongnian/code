    public static class StringExt {
        public static IEnumerable<string> SplitMetadataProperties(this string s) {
            var sb = new StringBuilder();
            bool inQuote = false;
            foreach (var ch in s) {
                switch (ch) {
                    case '[':
                        inQuote = true;
                        sb.Append(ch);
                        break;
                    case ']':
                        inQuote = false;
                        sb.Append(ch);
                        break;
                    case '|':
                        if (inQuote)
                            sb.Append(ch);
                        else {
                            if (sb.Length > 0) {
                                yield return sb.ToString();
                                sb.Clear();
                            }
                        }
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            if (sb.Length > 0)
                yield return sb.ToString();
        }    
    }
