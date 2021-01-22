    private static string ReverseString(string str)
        {
            return string.Create(str.Length, str, (chars, state) =>
            {
                var position = 0;
                var indexes = StringInfo.ParseCombiningCharacters(state); // skips string creation
                var stateSpan = state.AsSpan();
                for (int len = indexes.Length, i = len - 1; i >= 0; i--)
                {
                    var index = indexes[i];
                    var spanLength = i == len - 1 ? state.Length - index : indexes[i + 1] - index;
                    stateSpan.Slice(index, spanLength).CopyTo(chars.Slice(position));
                    position += spanLength;
                }
            });
        }
