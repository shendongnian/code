    public partial class FrontEndWaiting 
    {
        #region IsAnimated bool dependency property
        public static readonly DependencyProperty IsAnimatedProperty;
        
        #endregion
        static FrontEndWaiting()
        {
            IsAnimatedProperty =
                DependencyProperty.Register(
                "IsAnimated",
                typeof(bool),
                typeof(FrontEndWaiting),
                new UIPropertyMetadata(false));
        }
        /// <summary>
        /// Gets/sets the user controls IsAnimatedProperty.  
        /// This is a dependency property.
        /// The default value is 'true'.
        /// </summary>
        public bool IsAnimated
        {
            get { return (bool)GetValue(IsAnimatedProperty); }
            set { SetValue(IsAnimatedProperty, value); }
        }
       
        public FrontEndWaiting()
        {
            this.InitializeComponent();
            DependencyPropertyDescriptor prop = DependencyPropertyDescriptor.FromProperty(
                                                    IsAnimatedProperty,
                                                    typeof(FrontEndWaiting));
            prop.AddValueChanged(this, this.OnIsAnimatedPropertyChanged);
            
        }
        private void OnIsAnimatedPropertyChanged(object sender, EventArgs e)
        {
            Storyboard storyboard = LayoutRoot.FindResource("OnLoaded") as Storyboard;
            if (storyboard != null)
            {
                if (IsAnimated)
                {
                    storyboard.Begin();
                }
                else
                {
                    storyboard.Stop();
                }
            }
        }
    }
