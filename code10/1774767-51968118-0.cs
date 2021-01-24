    public class HttpClientPurpose
    {
        public override string ToString() => $"{{{this.GetType().Name} {this.UniqueName}}}";
        public override bool Equals(object other) => other is HttpClientPurpose typedOther && String.Equals(this.UniqueName, typedOther.UniqueName, StringComparison.OrdinalIgnoreCase);
        public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(this.UniqueName);
        internal static HttpClientPurpose GenericPurpose { get; } = new HttpClientPurpose("InternalGenericPurpose", () => new HttpClientHandler());
        public string UniqueName { get; }
        public Func<HttpMessageHandler> MessageHandlerFactory { get; }
        public HttpClientPurpose(string uniqueName, Func<HttpMessageHandler> messageHandlerFactory)
        {
            this.UniqueName = uniqueName ?? throw new ArgumentNullException(nameof(uniqueName));
            this.MessageHandlerFactory = messageHandlerFactory ?? throw new ArgumentNullException(nameof(messageHandlerFactory));
        }
    }
