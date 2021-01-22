    public partial class Form1 : Form
        {
            private static TextBox box;
    
            public Form1()
            {
                InitializeComponent();
            }
    
           
    
            private void Form1_Load(object sender, EventArgs e)
            {
               
                // box
                box = new TextBox();
                box.Location = new System.Drawing.Point(87, 230);
                box.Name = "box";
                box.Size = new System.Drawing.Size(100, 20);
                box.TabIndex = 1;
    
                this.Controls.Add(box);
    
            }
        }
