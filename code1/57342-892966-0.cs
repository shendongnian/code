        protected delegate void SelectAfterKeyPress(int start, int length);
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            String keypressed = e.KeyChar.ToString();
            if (keypressed == "}")
            {
                this.BeginInvoke(new SelectAfterKeyPress(Select), new object[] { 4, 9 });
            }
        }
