    [Register("myNamespace.SwitchRightText")]
    public class SwitchRightText : LinearLayout
    {
        public SwitchRightText(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            this.Init(context, attrs, defStyleAttr);
        }
        public SwitchRightText(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
            : base(context, attrs, defStyleAttr, defStyleRes)
        {
            this.Init(context, attrs, defStyleAttr, defStyleRes);
        }
        public SwitchRightText(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            this.Init(context, attrs);
        }
        public SwitchRightText(Context context)
            : base(context)
        {
            this.Init(context);
        }
        public SwitchRightText(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }
        // Controls
        public SwitchCompat Switch { get; set; }
        public TextView TextView { get; set; }
        private bool _toggleBackgrond;
        public bool ToggleBackground
        {
            get => this._toggleBackgrond;
            set
            {
                this._toggleBackgrond = value;
                this.UpdateBackground();
            }
        }
        // Methods
        private void Init(Context context = null, IAttributeSet attrs = null, int defStyleAttr = 0, int defStyleRes = 0)
        {
            if(IsInEditMode)
                return;
            this.Orientation = Orientation.Horizontal;
            this.InitializeSwitch(context, attrs);
            this.InitializeTextView(context, attrs);
            this.AddView(this.Switch);
            this.AddView(this.TextView);
        }
        private void InitializeSwitch(Context context, IAttributeSet attrs = null)
        {
            this.Switch = new SwitchCompat(context, attrs);
            this.Switch.ShowText = false;
        }
        private void InitializeTextView(Context context, IAttributeSet attrs = null)
        {
            this.TextView = new TextView(context, attrs);
        }
        private void UpdateBackground()
        {
            this.SetBackgroundColor(this.ToggleBackground ? Android.Graphics.Color.Black : Android.Graphics.Color.Yellow);
            this.Invalidate();
        }
    }
