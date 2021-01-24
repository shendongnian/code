    using System;
    using System.Threading;
    public static class CorrelationContext
    {
        private static readonly AsyncLocal<string> CorrelationId = new AsyncLocal<string>();
        public static void SetCorrelationId(string correlationId)
        {
            if (string.IsNullOrWhiteSpace(correlationId))
            {
                throw new ArgumentException(nameof(correlationId), "Correlation id cannot be null or empty");
            }
            if (!string.IsNullOrWhiteSpace(CorrelationId.Value))
            {
                throw new InvalidOperationException("Correlation id is already set");
            }
            CorrelationId.Value = correlationId;
        }
        public static string GetCorrelationId()
        {
            return CorrelationId.Value;
        }
    }
