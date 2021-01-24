    public sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();        
        public int SomeValue
        {
            get => (int)GetValue(SomeValueProperty);
            set => SetValue(SomeValueProperty, value);
        }
        public static readonly DependencyProperty SomeValueProperty = //Notice this is static and it's bound to an internal static hash table of some sort; I use to know exactly but forgot.
            DependencyProperty.Register(
                nameof(SomeValue), /*The name of the property to register against. 
                                   * The static version is always the name of the property ended with Property
                                   * i.e. SomeValue property is SomeValueProperty dependency property */                                                 
                typeof(int), //This is the type used to describe the property.
                typeof(MainPage), //This is the type the dependency property relates to. 
                /* Below this is the magic. It's where we supply the property meta data and can be delivered different ways.
                * For this example I will supply only the default value and the event we want to use when the value is changed.
                * Note: 
                * The event we supply is fired ONLY is the value is changed and is what we need to use to handle changes in the setter to cover binding operations as well. */
                new PropertyMetadata(default(int),  /* This is the default value the dependency property will have. 
                                                    * It can be whatever you decide but make sure it works with the same type or you'll most likely get an error. */
                    /* This is the event fired when the value changes.
                     * Note: Dependency properties always operate on the UI thread. Cross threading will throw exceptions. */
                    new PropertyChangedCallback((s, e) =>
                    {
                        var mainPage = s as MainPage; //The sender of the callback will always be of the type it's from.
                        /* The values given from the e argument for OldValue and NewValue should be of type int in this example...
                         * but since we can't gaurantee the property is setup properly before here I always add a check. */
                        if (e.OldValue is int oldValue) { }
                        if (e.NewValue is int newValue) 
                        { 
                             /* Now do what you want with the information.  This is where you need to do custom work instead of using the setter.
                              * Note: If you need to work on something in the MainPage remember this is a static event and you'll need to refer to the sender or s value in this case.
                              * I've converted s to the variable mainPage for easy referencing here. */
                             mainPage.MyCustomControl.Value = newValue;
                        }
                    })));
    }
