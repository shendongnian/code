        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SetAnimationBindings();
        }
        private void SetAnimationBindings()
        {
            _dialogStartPosition = mbFolderBrowse.Margin;
            var propName = "StartDialogAnimation";
            var binding = new Binding(propName) { Mode = BindingMode.TwoWay };
            this.SetBinding(DialogAnimationProperty, binding);
            propName = "StartProgressAnimation";
            binding = new Binding(propName) { Mode = BindingMode.TwoWay };
            this.SetBinding(ProgressAnimationProperty, binding);
        }
        #region Animation Properties
        #region DialogAnimation
        public static readonly DependencyProperty DialogAnimationProperty = 
            DependencyProperty.Register("DialogAnimation", typeof(bool),
                typeof(Manage), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnDialogAnimationChanged));
        public bool DialogAnimation
        {
            get { return (bool)this.GetValue(DialogAnimationProperty); }
            set
            {
                var oldValue = (bool)this.GetValue(DialogAnimationProperty);
                if (oldValue != value) this.SetValue(DialogAnimationProperty, value);
            }
        }
        private static void OnDialogAnimationChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            Manage m = o as Manage;
            if ((bool)e.NewValue == true)
                m.SlideInDialogPanel(); // animations
            else
                m.SlideOutDialogPanel();
        }
        #endregion
