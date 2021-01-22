        public static int GetGroupboxTextHeightExtra(GroupBox box) {
            TextFormatFlags flags = TextFormatFlags.Default | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak | TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.PreserveGraphicsClipping;
            Rectangle rc = new Rectangle(0, 0, box.Width - 2 * 7, box.Height);
            Size size;
            using (Graphics gr = Application.OpenForms[0].CreateGraphics()) {
                size = TextRenderer.MeasureText(gr, box.Text, box.Font, rc.Size, flags);
            }
            return size.Height - box.Font.Height;
        }
