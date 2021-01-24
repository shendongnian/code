        public partial class MainMenu : Form
            {
                public static StoreData Data { get; set; }   //static property
    
                private void MainMenu_Load(object sender, EventArgs e)
                {
                    Data = new StoreData { MyProperty = 1 };
                }
            }
