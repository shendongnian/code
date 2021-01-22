    public class MyTextbox : TextBox {
        Font mFont;
        public MyTextbox() {
            base.Font = mFont = new Font("Courier New", 12f, FontStyle.Regular, GraphicsUnit.Point);
        }
    
        [ReadOnly(true)]
        public override Font Font {
            get { return mFont; }
        }
    }
