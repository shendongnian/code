        public void setBoxText(string value)
        {
            if (InvokeRequired)
                Invoke(new SetTextDelegate(setBoxText), value);
            else
                statusBox.Text += value;
        }
        delegate void SetTextDelegate(string value); 
