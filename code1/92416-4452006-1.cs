    [ThreadStatic]
    static RichTextBox m_RtfConverter;
    public static RichTextBox ThreadSafeRTFConverter {
        get {
            if(RichTextBox == null) {
                m_RtfConverter = new RichTextBox();
                m_RtfConverter.Width = 760;
            }
            return m_RtfConverter;
        }
    }
