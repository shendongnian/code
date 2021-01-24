    public interface IAddable {
        /// <summary >
        /// This is the value we want.
        /// </summary>
        int Value { get; set; }
        IAddable Add(IAddable x, IAddable y);
    }
    public class Number : IAddable {
        public Number() { }
        public Number(int num) => Value = num;
        public int Value { get; set; }
        public IAddable Add(IAddable x, IAddable y) {
            return (Number)(x.Value + y.Value);
        }
        public static implicit operator Number(int num) => new Number(num);
        public static implicit operator Number(double num) => new Number((int)num);
        public static implicit operator int(Number num) => num.Value;
    }
