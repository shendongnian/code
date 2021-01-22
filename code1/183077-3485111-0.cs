    class MyButton : Button
    {
        public MyButton() : base()
        {
            this.BackColor = System.Drawing.Color.AntiqueWhite;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Blue;
            base.OnEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            base.OnLeave(e);
        }
    }
