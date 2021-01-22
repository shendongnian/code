    public class GrowLabel : Label {
        private bool mGrowing;
        public GrowLabel() {
            this.AutoSize = false;
        }
        private void resizeLabel() {
            if (mGrowing)
                return;
            try {
                mGrowing = true;
                int width = this.Parent == null ? this.Width : this.Parent.Width;
                Size sz = new Size(this.Width, Int32.MaxValue);
                sz = TextRenderer.MeasureText(this.Text, this.Font, sz, TextFormatFlags.WordBreak);
                this.Height = sz.Height + Padding.Bottom + Padding.Top;
            } finally {
                mGrowing = false;
            }
        }
        protected override void OnTextChanged(EventArgs e) {
            base.OnTextChanged(e);
            resizeLabel();
        }
        protected override void OnFontChanged(EventArgs e) {
            base.OnFontChanged(e);
            resizeLabel();
        }
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            resizeLabel();
        }
    }
