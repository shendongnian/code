    public partial class Form1 : Form
    {
        //stores the booleans in a list
        private readonly List<bool> _values = new List<bool>();
        //I use a random to generate the booleans _random.Next(2) will produce either 0 or 1 and _random.Next(2) == 1 will give true on 1 and false on 0
        private readonly Random _random = new Random();
        public Form1()
        {
            InitializeComponent();
            //fill the list
            FillValues();
            //iterate over the list
            for (var index = 0; index < _values.Count; index++)
            {
                //create a button for each entry
                var btn = new Button();
                btn.Name = "Values" + index; //dont need the name, but you can fill it as you see fit
                btn.Width = 70; //set the width as you desire
                btn.Height = 20; //set the height as you desire
                btn.Text = btn.Name; //set a text if you like to, I used the .Name
                //some math to position the buttons, I here use a grid of 12 since you mentioned your naming scheme changes at 12 S1Di1 -> S1Di12 and than S2Di1 -> S2Di12
                btn.Top = (index / 12) * (btn.Height + btn.Margin.Top); 
                btn.Left = (index % 12) * (btn.Width + btn.Margin.Left);
                panel1.Controls.Add(btn); //add the button to a panel thats inside your form, only the buttons that get created here should be inside that panel nothing more
            }
            //update the colors of the button
            UpdateColors();
        }
        private void FillValues()
        {
            //clear the values, before filling it
            _values.Clear();
            //you mentioned 200 buttons, so here is a for loop for 200 entries and fill the values with a bool
            for (int i = 0; i < 200; i++)
                _values.Add(_random.Next(2) == 1);
            //of course you dont need to clear the list and re-add the items everytime this method gets called, you can check if (_values.Count == 0) and only than add the items and in else set the new values with _values[i] = newValue - its just the lazy way :)
        }
        private void UpdateColors()
        {
            //iterate over the list and set the panels Controls[index] to the color - the index will match with the list since you have created the buttons based on the list previously
            for (int i = 0; i < _values.Count; i++)
                panel1.Controls[i].BackColor = _values[i] ? Color.LawnGreen : Color.DarkGray;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //to have new bools in list fill the values
            FillValues();
            //update the colors
            UpdateColors(); 
        }
    }
