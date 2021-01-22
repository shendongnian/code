    public struct Nullable<T> where T : struct
    {
        public override string ToString()
        {
          if (!this.hasValue)
            return "";
          return this.value.ToString();
        }
    }
