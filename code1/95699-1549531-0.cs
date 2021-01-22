    class DerivedLabel : Label
    {
        public override string Text
        {
            get
            {
                return Invoke(new Func<string>(GetText)) as string;
            }
            set
            {
                Invoke(new Action<string>(SetText), value);
            }
        }
        private void SetText(string text)
        {
            base.Text = text;
        }
        private string GetText()
        {
            return base.Text;
        }
    }
