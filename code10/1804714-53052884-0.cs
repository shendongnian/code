        [Theory]
        [InlineData("My test dogs with a single dog and some text behind", "dog", "My test dogs with a single <strong>dog</strong> and some text behind")]
        public void Highlight_exact_match_only(string input, string textToHighlight, string expected)
        {
            // given
            var escapedHighlight = Regex.Escape(textToHighlight);
            // when
            var result = Regex.Replace(input, $@"\b{escapedHighlight}\b", m => $@"<strong>{m.Groups[0].Value}</strong>");
            Assert.Equal(expected, result);
        }
