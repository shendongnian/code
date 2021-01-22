    class PlainRichTextBox : RichTextBox
    {
        const int WM_USER = 0x400;
        const int EM_SETTEXTMODE = WM_USER + 89;
        const int EM_GETTEXTMODE = WM_USER + 90;
        // EM_SETTEXTMODE/EM_GETTEXTMODE flags
        const int TM_PLAINTEXT = 1;
        const int TM_RICHTEXT = 2;          // Default behavior 
        const int TM_SINGLELEVELUNDO = 4;
        const int TM_MULTILEVELUNDO = 8;    // Default behavior 
        const int TM_SINGLECODEPAGE = 16;
        const int TM_MULTICODEPAGE = 32;    // Default behavior 
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        bool m_PlainTextMode;
        // If this property doesn't work for you from the designer for some reason
        // (for example framework version...) then set this property from outside
        // the designer then uncomment the Browsable and DesignerSerializationVisibility
        // attributes and set the Property from your component initializer code
        // that runs after the designer's code.
        [DefaultValue(false)]
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool PlainTextMode
        {
            get
            {
                return m_PlainTextMode;
            }
            set
            {
                m_PlainTextMode = value;
                if (IsHandleCreated)
                {
                    IntPtr mode = value ? (IntPtr)TM_PLAINTEXT : (IntPtr)TM_RICHTEXT;
                    SendMessage(Handle, EM_SETTEXTMODE, mode, IntPtr.Zero);
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            // For some reason it worked for me only if I manipulated the created
            // handle before calling the base method.
            PlainTextMode = m_PlainTextMode;
            base.OnHandleCreated(e);
        }
    }
