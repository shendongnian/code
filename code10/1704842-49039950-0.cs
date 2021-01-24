    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++) //simple loop just to simulate the request
            {
                createContractButton();  //will generate 3 contractButtons with Visible = true
                // createInfoButton(); - Don't do this here
            }
        }
        private Button createInfoButton()
        {
            Button infoButton = infoButtonCreration("infoButton");
            flowLayoutPanel1.Controls.Add(infoButton);
            infoButton.Click += new EventHandler(btnInfo_Click);
            return infoButton;
        }
        private void createContractButton()
        {
            MyCustomButton contractButton = contractButtonCreation("contractButton");
            flowLayoutPanel1.Controls.Add(contractButton);
            contractButton.Click += new EventHandler(btn_Click);
            // Create new infoButton here, tied directly to the ContractButton you have just created
            contractButton.InfoButton = this.createInfoButton();
        }
        MyCustomButton contractButtonCreation(string contract)
        {
            MyCustomButton b = new MyCustomButton();
            b.FlatAppearance.BorderSize = 1;
            b.FlatStyle = FlatStyle.Flat;
            b.Name = contract;
            b.Size = new Size(150, 80);
            b.Text = contract;
            b.UseVisualStyleBackColor = false;
            return b;
        }
        Button infoButtonCreration(string info)
        {
            Button b = new Button();
            b.FlatAppearance.BorderSize = 1;
            b.FlatStyle = FlatStyle.Flat;
            b.Name = info;
            b.Size = new Size(70, 80);
            b.Text = info;
            b.UseVisualStyleBackColor = false;
            b.Visible = false;         //this with make the button hidden
            return b;
        }
        private void btn_Click(object sender, EventArgs e)
        {
            //here i need the magic, on click i need the infoButton nect to me to be visible
            MyCustomButton button = sender as MyCustomButton;
            button.InfoButton.Visible = true;
        }
        private void btnInfo_Click(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            b.Text = "name"; //simple even when button gets visible so i can test it woeks
        }
    }
    public class MyCustomButton : Button
    {
        public Button InfoButton { get; set; }
    }
