        private enum State
        {
            None = 0,
            InTokin,
            InQuote
        }
        private static IEnumerable<string> Tokinize(string input)
        {
            input += ' '; // ensure we end on whitespace
            State state = State.None;
            State? next = null; // setting the next state implies that we have found a tokin
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                switch (state)
                {
                    default:
                    case State.None:
                        if (char.IsWhiteSpace(c))
                            continue;
                        else if (c == '"')
                        {
                            state = State.InQuote;
                            continue;
                        }
                        else
                            state = State.InTokin;
                        break;
                    case State.InTokin:
                        if (char.IsWhiteSpace(c))
                            next = State.None;
                        else if (c == '"')
                            next = State.InQuote;
                        break;
                    case State.InQuote:
                        if (c == '"')
                            next = State.None;
                        break;
                }
                if (next.HasValue)
                {
                    yield return sb.ToString();
                    sb = new StringBuilder();
                    state = next.Value;
                    next = null;
                }
                else
                    sb.Append(c);
            }
        }
