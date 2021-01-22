    namespace Application.Code.Helpers
    {
        public static class StringBuilderExtensions
        {
            #region Methods
            public static void Prepend(this StringBuilder sb, string value)
            {
                sb.Insert(0, value);
            }
            public static void PrependLine(this StringBuilder sb, string value)
            {
                sb.Insert(0, value + Environment.NewLine);
            }
            #endregion
        }
    }
