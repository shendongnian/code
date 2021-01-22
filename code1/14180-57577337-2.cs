    private static string ReverseString(string str)
        {
            return string.Create(str.Length, str, (chars, state) =>
            {
                var enumerator = StringInfo.GetTextElementEnumerator(state);
                var position = state.Length;
                while (enumerator.MoveNext())
                {
                    var cluster = ((string)enumerator.Current).AsSpan();
                    cluster.CopyTo(chars.Slice(position - cluster.Length));
                    position -= cluster.Length;
                }
            });
        }
