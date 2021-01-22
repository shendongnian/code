    public delegate void updateFormTextD(string text);
    private void formText(string text)
    {
         this.Text = text;
    }
    private void updateFormText(string text)
    {
         Invoke(new updateFormTextD(formText), text);
    }
