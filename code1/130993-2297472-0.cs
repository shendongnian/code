        public void setLabelText(string value)
        {
            if (InvokeRequired)
                Invoke(new SetTextDelegate(setLabelText), value);
            else
                label1.Text = value;
        }
        delegate void SetTextDelegate(string value); 
