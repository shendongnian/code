    public class ErrorFlag // base enum class
    {
        int value;
        ErrorFlag() 
        {
        
        }
        public static implicit operator ErrorFlag(int i)
        {
            return new ErrorFlag { value = i };
        }
        public bool Equals(ErrorFlag other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (ReferenceEquals(null, other))
                return false;
            return value == other.value;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ErrorFlag);
        }
        public static bool operator ==(ErrorFlag lhs, ErrorFlag rhs)
        {
            if (ReferenceEquals(lhs, null))
                return ReferenceEquals(rhs, null);
            return lhs.Equals(rhs);
        }
        public static bool operator !=(ErrorFlag lhs, ErrorFlag rhs)
        {
            return !(lhs == rhs);
        }
        public override int GetHashCode()
        {
            return value;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
    
    public interface IError<T> where T : ErrorFlag
    {
        T ErrorCode;
        string Description;
    }
