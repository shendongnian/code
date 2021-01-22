    private bool mSubscribed;
    private void Subscribe(bool enabled)
    {
        if (!enabled)
        {
            textBox1.VisibleChanged -= textBox1_VisibleChanged;
        }
        else 
        {
            if (!mSubscribed)
            {
                textBox1.VisibleChanged += textBox1_VisibleChanged;
            }
        }
        mSubscribed = enabled;
    }
