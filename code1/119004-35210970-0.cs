    private void Form1_Load(object sender, EventArgs e)
        {
            MyCar car1 = new MyCar();
            this.propertyGrid1.SelectedObject = car1;
        }
        public class MyCar{
            //*****************************
            private Color MyColor_ = Color.Red;//<------------------------ Here
            //*****************************
            public Color MyColor
            {
                get { return MyColor_; }
                set { this.MyColor_ = value; }
            }
            
            private String Id_;
            public String Id
            {
                get { return Id_; }
                set { this.Id_ = value; }
            }
        }
