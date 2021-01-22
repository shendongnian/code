    public static class Extensions
    {
        public static string ToSentence( this string Input )
        {
            return new string( Input.ToCharArray().SelectMany(c => char.IsUpper(c) ? new char[] {' ', c} : new char[] {c}).ToArray() );
        }
    }
