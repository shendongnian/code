    [ContentProperty("StatusText")]
    public sealed class StatusTextBlock : TextBlock
    {
        #region Fields
        public static readonly DependencyProperty StatusTextProperty = DependencyProperty.Register(
                                                                                        "StatusText", 
                                                                                              typeof(string),
                                                                                        typeof(StatusTextBlock),
                                                                                        new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.None, StatusTextBlock.StatusTextPropertyChangedCallback, null));
        private static readonly Regex UriMatchingRegex = new Regex(@"(?<url>[a-zA-Z]+:\/\/[a-zA-Z0-9]+([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,5}(:[0-9]{1,5})?([a-zA-Z0-9_\-\.\~\%\+\?\=\&\;\|/]*)?)|(?<emailAddress>[^\s]+@[a-zA-Z0-9]+([\-\.]{1}[a-zA-Z0-9]+)*\.[a-zA-Z]{2,5})|(?<toTwitterScreenName>\@[a-zA-Z0-9\-_]+)", RegexOptions.Compiled);
        #endregion
        #region Constructors
        public StatusTextBlock()
        {
        }
        #endregion
        #region Type specific properties
        public string StatusText
        {
            get
            {
                return (string)this.GetValue(StatusTextBlock.StatusTextProperty);
            }
            set
            {
                this.SetValue(StatusTextBlock.StatusTextProperty, value);
            }
        }
        #endregion
        #region Helper methods
        internal static IEnumerable<Inline> GenerateInlinesFromRawEntryText(string entryText)
        {
            int startIndex = 0;
            Match match = StatusTextBlock.UriMatchingRegex.Match(entryText);
            while(match.Success)
            {
                if(startIndex != match.Index)
                {
                    yield return new Run(StatusTextBlock.DecodeStatusEntryText(entryText.Substring(startIndex, match.Index - startIndex)));
                }
                Hyperlink hyperLink = new Hyperlink(new Run(match.Value));
                string uri = match.Value;
                if(match.Groups["emailAddress"].Success)
                {
                    uri = "mailto:" + uri;
                }
                else if(match.Groups["toTwitterScreenName"].Success)
                {
                    uri = "http://twitter.com/" + uri.Substring(1);
                }
                hyperLink.NavigateUri = new Uri(uri);
                yield return hyperLink;
                startIndex = match.Index + match.Length;
                match = match.NextMatch();
            }
            if(startIndex != entryText.Length)
            {
                yield return new Run(StatusTextBlock.DecodeStatusEntryText(entryText.Substring(startIndex)));
            }
        }
        internal static string DecodeStatusEntryText(string text)
        {
            return text.Replace("&gt;", ">").Replace("&lt;", "<");
        }
        private static void StatusTextPropertyChangedCallback(DependencyObject target, DependencyPropertyChangedEventArgs eventArgs)
        {
            StatusTextBlock targetStatusEntryTextBlock = (StatusTextBlock)target;
            targetStatusEntryTextBlock.Inlines.Clear();
            string newValue = eventArgs.NewValue as string;
            if(newValue != null)
            {
                targetStatusEntryTextBlock.Inlines.AddRange(StatusTextBlock.GenerateInlinesFromRawEntryText(newValue));
            }
        }
        #endregion
    }
