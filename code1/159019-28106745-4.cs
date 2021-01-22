    public class ResourceLoader : DynamicObject
    {
        #region Fields ---------------------------------------------------------------
        private const string DefaultResourcesSuffix = "Resource";
        private ResourceManager _resourceMan;
        private CultureInfo culture;
        private readonly string _defaultAssemblyName;
        private readonly Assembly _defaultAssembly;
        private Assembly theAssembly;
        private string resourcesSuffix;
        private string assembly;
        #endregion // Fields
        #region Properties -----------------------------------------------------------
        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        public string Assembly
        {
            get { return assembly; }
            set
            {
                assembly = value;
                theAssembly = System.Reflection.Assembly.Load(assembly);
                _resourceMan = null;
            }
        }
        /// <summary>
        /// Gets or sets the resources suffix.
        /// </summary>
        public string ResourcesSuffix
        {
            get { return resourcesSuffix; }
            set
            {
                resourcesSuffix = value;
                _resourceMan = null;
            }
        }
        /// <summary>
        /// Get, set culture
        /// </summary>
        public CultureInfo CurrentCulture
        {
            get { this.culture = this.culture ?? CultureInfo.InvariantCulture; return this.culture; }
            set { this.culture = value; }
        }
        /// <summary>
        /// Creates new instace of <see cref="System.Resources.ResourceManager"/> at initialisation or change of <see cref="ResourceFileAccessSample.ResourceBinding.ResourceLoader.Assembly"/>.
        /// </summary>
        private ResourceManager ResourceManager
        {
            get
            {
                if (ReferenceEquals(_resourceMan, null))
                {
                    ResourceManager temp = new ResourceManager(
                        string.Format("{0}.{1}", Assembly ?? _defaultAssemblyName, ResourcesSuffix ?? DefaultResourcesSuffix),
                        theAssembly ?? _defaultAssembly);
                    _resourceMan = temp;
                }
                return _resourceMan;
            }
        }
        #endregion // Properties
        #region Methods --------------------------------------------------------------
        private object GetResource(string name, CultureInfo language)
        {
            if (language == null || language == CultureInfo.InvariantCulture)
                return ResourceManager.GetObject(name);
            return ResourceManager.GetObject(name, language);
        }
        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject"/> class can override this method to specify dynamic behavior for operations such as getting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject"/> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result"/>.</param>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a run-time exception is thrown.)
        /// </returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = GetResource(binder.Name, this.culture);
            if (result != null && result.GetType() == typeof(System.Drawing.Bitmap))
            {
                System.Drawing.Bitmap currentBmp = result as System.Drawing.Bitmap;
                currentBmp.MakeTransparent(System.Drawing.Color.Magenta);
                BitmapSource src = Imaging.CreateBitmapSourceFromHBitmap(currentBmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                result = src;
            }
            return result == null ? false : true;
        }
        /// <summary>
        /// Switch set culture
        /// </summary>
        public void SwitchCulture(CultureInfo NewCulture)
        {
            this.culture = NewCulture;
        }
        #endregion // Methods
        #region Constructors ---------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceLoader"/> class.
        /// </summary>
        public ResourceLoader()
            : this(CultureInfo.InvariantCulture, DefaultResourcesSuffix)
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceLoader"/> class.
        /// </summary>
        public ResourceLoader(CultureInfo InitCulture, string ResourceSuffix)
        {
            _defaultAssemblyName = GetType().Assembly.GetName().Name;
            _defaultAssembly = GetType().Assembly;
            this.culture = InitCulture;
            this.resourcesSuffix = ResourceSuffix;
        }
        #endregion // Constructors
    }
    
