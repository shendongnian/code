        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            if (string.IsNullOrEmpty(Text))
            {
                this.BorderStyle = BorderStyle.FixedSingle;
            }
            else 
            {
                this.BorderStyle = BorderStyle.Fixed3D;
            }
        }
