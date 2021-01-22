    public class ErrorFlag // base enum class
    {
        internal int value { get; set; }
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
        T ErrorCode { get; set; }
        string Description { get; set; }
    }
    //enum classes
    public sealed class ReportErrorFlag : ErrorFlag
    {
        //basically your enum values
        public static readonly ReportErrorFlag Report1 = new ReportErrorFlag { value = 1 };
        public static readonly ReportErrorFlag Report2 = new ReportErrorFlag { value = 2 };
        public static readonly ReportErrorFlag Report3 = new ReportErrorFlag { value = 3 };
        ReportErrorFlag()
        {
        }
    }
    public sealed class DataErrorFlag : ErrorFlag
    {
        //basically your enum values
        public static readonly DataErrorFlag Data1 = new DataErrorFlag { value = 1 };
        public static readonly DataErrorFlag Data2 = new DataErrorFlag { value = 2 };
        public static readonly DataErrorFlag Data3 = new DataErrorFlag { value = 3 };
        DataErrorFlag()
        {
        }
    }
    //implement the rest
