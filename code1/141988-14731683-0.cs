    class Foo
    {
        public Foo() { Bar = new Bar(); }
        public Bar Bar { get; set; }
    }
    class Bar
    {
        public string Value { get; set; }
    }
    class BarTypeDescriptionProvider : TypeDescriptionProvider
    {
        private TypeDescriptionProvider _baseProvider;
        string _extraParam;
        public BarTypeDescriptionProvider(Type t, string extraParam)
        {
            this._extraParam = extraParam;
            _baseProvider = TypeDescriptor.GetProvider(t);
        }
        public string ExtraParam
        { 
            get { return _extraParam; } 
        }
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return new BarTypeDescriptor(this, _baseProvider.GetTypeDescriptor(objectType, instance), objectType);
        }
    }
    class BarTypeDescriptor : CustomTypeDescriptor
    {
        private Type _objectType;
        private BarTypeDescriptionProvider _provider;
        public BarTypeDescriptor(BarTypeDescriptionProvider provider,  ICustomTypeDescriptor descriptor, Type objectType): base(descriptor)
        {
            if (provider == null) throw new ArgumentNullException("provider");
            if (descriptor == null)
                throw new ArgumentNullException("descriptor");
            if (objectType == null)
                throw new ArgumentNullException("objectType");
            _objectType = objectType;
            _provider = provider;
        }
        public override object GetEditor(Type editorBaseType)
        {
            return new BarEditor(_provider.ExtraParam);
        }
    }
    class BarEditor : UITypeEditor
    {
        private string _extraParam;
        public BarEditor(string x)
            : base()
        {
            _extraParam = x;
        }
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            MessageBox.Show(_extraParam);
            return base.EditValue(context, provider, value);
        }
    }
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string extraParam = "Extra param from main form";
            TypeDescriptor.AddProvider(new BarTypeDescriptionProvider(typeof(Bar), extraParam), typeof(Bar));
            this.propertyGrid1.SelectedObject = new Foo();
        }
    }
