    public static class CsvImport {
        /// <summary>
        /// Parse a Comma Separated Value (CSV) source into rows of strings. [1]
        /// 
        /// The header row (if present) is not treated specially. No checking is
        /// performed to ensure uniform column lengths among rows. If no input
        /// is available, a single row containing String.Empty is returned. No
        /// support is provided for debugging invalid CSV files. Callers who
        /// desire such assistance are encouraged to use a TextReader that can
        /// report the current line and column position.
        /// 
        /// [1] http://tools.ietf.org/html/rfc4180
        /// </summary>
        public static IEnumerable<string[]> Deserialize(TextReader input) {
            if (input.Peek() == Sentinel) yield return new [] { String.Empty };
            while (input.Peek() != Sentinel) {
                // must read in entire row *now* to see if we're at end of input
                yield return DeserializeRow(input).ToArray(); 
            }
        }
        const int Sentinel = -1;
        const char Quote = '"';
        const char Separator = ',';
        static IEnumerable<string> DeserializeRow(TextReader input) {
            var field = new StringBuilder();
            while (true) {
                var c = input.Read();
                if (c == Separator) {
                    yield return field.ToString();
                    field = new StringBuilder();
                } else if (c == '\r') {
                    if (input.Peek() == '\n') {
                        input.Read();
                    }
                    yield return field.ToString();
                    yield break;
                } else if (new [] { '\n', Sentinel }.Contains(c)) {
                    yield return field.ToString();
                    yield break;
                } else if (c == Quote) {
                    field.Append(DeserializeQuoted(input));
                } else {
                    field.Append((char) c);
                }
            }
        }
        static string DeserializeQuoted(TextReader input) {
            var quoted = new StringBuilder();
            while (input.Peek() != Sentinel) {
                var c = input.Read();
                if (c == Quote) {
                    if (input.Peek() == Quote) {
                        quoted.Append(Quote);
                        input.Read();
                    } else {
                        return quoted.ToString();
                    }
                } else {
                    quoted.Append((char) c);
                }
            }
            throw new UnexpectedEof("End-of-file inside quoted section.");
        }
        public class UnexpectedEof : Exception {
            public UnexpectedEof(string message) : base(message) { }
        }
    }
