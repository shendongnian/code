        // code outside the myForm:-----------------------
        if (myForm.InvokeRequired)
            myForm.Invoke(new ChangeLabelEventHandler(ChangeLabel), "teeeest");
        else
            myForm.ChangeLabel("teeeest");
        // code in the myForm:-----------------------------
        public delegate void ChangeLabelEventHandler(string newText);
        private void ChangeLabel(string newLabelText)
        {
            this.label1.Text = newLabelText;
        }
