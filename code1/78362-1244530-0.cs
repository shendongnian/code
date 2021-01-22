    public interface ICurrencyWriter {
        string Write(int i);
        string Write(float f);
    }
    public class DelegatedCurrencyWriter : ICurrencyWriter {
        public DelegatedCurrencyWriter()
        {
            IntWriter = i => i.ToString();
            FloatWriter = f => f.ToString();
        }
        public string Write(int i) { return IntWriter(i); }
        public string Write(float f) { return FloatWriter(f); }
        public Func<int, string> IntWriter { get; set; }
        public Func<float, string> FloatWriter { get; set; }
    }
    public class SingletonCurrencyWriter {
        public static DelegatedCurrencyWriter Writer {
            get {
                if (_writer == null)
                   _writer = new DelegatedCurrencyWriter();
                return _writer;
            }
        }
    }
