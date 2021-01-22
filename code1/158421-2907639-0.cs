    public partial class MyMainForm {
        private TextBox textBox1;
        public MyMainForm() {
            textBox1 = new Textbox();
            textBox1.Name = @"textBox1";
            textBox1.Location = new Point(10, 10);
            textBox1.Size = new Size(150, 23);
            this.Controls.Add(textBox1);
        }
        public Font MyTextBoxFont {
            get {
                return textBox1.Font;
            } set {
                if (value == null) return;
                textbox1.Font = value;
            }
        }
    }
