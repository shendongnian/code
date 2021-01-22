    static void Main(string[] args)
    {
    Application.EnableVisualStyles();
            Form frm = new Form();  // create aForm object
            Button btn = new Button()
            {
                Left = 120,
                Width = 130,
                Height = 30,
                Top = 150,
                Text = "Biju Joseph, Redmond, WA"
            };
           //… more code 
           frm.Controls.Add(btn);  // add button to the Form
           //  …. add more code here as needed
             
           frm.ShowDialog(); // a modal dialog 
    }
