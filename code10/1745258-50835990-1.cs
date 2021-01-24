    public class TextShape : Shape {
        private string text;
        public string Text {
            get { return text; }
            set {
                if (text != value) {
                    text = value;
                    OnPropertyChanged();
                }
            }
        }
        private Point location;
        public Point Location {
            get { return location; }
            set {
                if (!location.Equals(value)) {
                    location = value;
                    OnPropertyChanged();
                }
            }
        }
        private Font font;
        public Font Font {
            get { return font; }
            set {
                if (font!=value) {
                    font = value;
                    OnPropertyChanged();
                }
            }
        }
        private Color color;
        public Color Color {
            get { return color; }
            set {
                if (color!=value) {
                    color = value;
                    OnPropertyChanged();
                }
            }
        }
        public override void Draw(Graphics g) {
            using (var brush = new SolidBrush(Color))
                g.DrawString(Text, Font, brush, Location);
        }
        public override Shape Clone() {
            return new TextShape() {
                Text = Text,
                Location = Location,
                Font = (Font)Font.Clone(),
                Color = Color
            };
        }
    }
