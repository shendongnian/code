    [ThreadStatic]
    static RichTextBox m_RtfConverter;
    public static RichTextBox ThreadSafeRTFConverter {
        get {
            if(m_RtfConverter == null) {
                m_RtfConverter = new RichTextBox();
                m_RtfConverter.Width = 760;
            }
            return m_RtfConverter;
        }
    }
