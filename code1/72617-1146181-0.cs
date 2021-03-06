    class Program
    {
        static void Main(string[] args)
        {
            Asset certainAsset = new Asset(32423);
            foreach (AssetDataField dataField in certainAsset.DataFields)
            {
                dataField.Deal();
            }
        }
    }
    class Asset
    {
        public List<AssetDataField> DataFields = new List<AssetDataField>();
        public Asset(int id)
        {
            // Load asset #id
            if (id == 32423)
            {
                DataFields.Add(new AssetDataFieldString());
                DataFields.Add(new AssetDataFieldFloat());
            }
        }
    }
    abstract class AssetDataField
    {
        public AssetDataField()
        {
            FieldValue = DefaultValue;
        }
        public abstract object DefaultValue { get; }
        public abstract object FieldValue { get; set; }
        public abstract void Deal();
    }
    abstract class AssetDataFieldType<T> : AssetDataField
    {
        protected T internalValue;
        public override object FieldValue
        {
            get
            {
                return TypedValue;
            }
            set
            {
                internalValue = (T)System.Convert.ChangeType(value, typeof(T));
            }
        }
        public T TypedValue
        {
            get
            {
                return internalValue;
            }
            set
            {
                internalValue = value;
            }
        }
    }
    class AssetDataFieldString : AssetDataFieldType<string>
    {
        public override object DefaultValue
        {
            get { return "Default String"; }
        }
        public override void Deal()
        {
            Console.WriteLine(internalValue.PadLeft(20));
        }
    }
    class AssetDataFieldFloat : AssetDataFieldType<float>
    {
        public override object DefaultValue
        {
            get { return 0; }
        }
        public override void Deal()
        {
            Console.WriteLine(internalValue.ToString("#0.000"));
        }
    }
