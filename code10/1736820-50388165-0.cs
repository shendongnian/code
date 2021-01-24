    public class Sample<T> where T : struct
    {
        ...
        [Obsolete("error", true)]
        public static implicit operator Sample<T>(T? value) => throw new NotImplementedException();
    }
