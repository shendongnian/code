        delegate void TextProcessor([NotNull] string text);
        delegate void NullableTextProcessor([CanBeNull] string text);
        private void DoSomething([NotNull] TextProcessor processText)
        {
            // ...
        }
        private void DoSomethingNull([NotNull] NullableTextProcessor processText)
        {
            // ...
        }
