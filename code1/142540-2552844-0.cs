    public class Target
    {
        private int _myInt = 1;
        public int MyInt { set; get; }
    
        public static Target target = new Target();
    }
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
    
            Button button = new Button()
            {
                Text = "Click me",
                Dock = DockStyle.Bottom
            };
    
            Form form = new Form
            {
                Controls = {
                    new PropertyGrid {
                        SelectedObject = Target.target,
                        Dock = DockStyle.Fill,
                    },
                    button
                }
            };
    
            button.Click += new EventHandler(button_Click);
            Application.Run(form);
        }
    
        static void button_Click(object sender, EventArgs e)
        {
            Target.target.MyInt = 2;
            Form form = Form.ActiveForm;
            (form.Controls[0] as PropertyGrid).Refresh();
        }
    }
