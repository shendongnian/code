    namespace CloneAControl
    {
        public partial class Form1 : Form
        {
            private int yValue = 50;
            public Form1()
            {
                InitializeComponent();
            }
            private void button3_Click(object sender, EventArgs e)
            {
                Panel ctrl = panel1.Clone();
                //Control ctrl = ControlFactory.CloneCtrl(this.panel1);
                this.Controls.Add(ctrl);
                //ctrl.Text = "created by clone";
                ctrl.SetBounds(ctrl.Bounds.X, ctrl.Bounds.Y + yValue,
                               ctrl.Bounds.Width, ctrl.Bounds.Height);
                yValue = yValue + 50;
                ctrl.BackColor = Color.Red;
                ctrl.Show();
            }
        }
        public static class ControlExtensions
        {
            public static T Clone<T>(this T controlToClone)
                where T : Control
            {
                PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                T instance = Activator.CreateInstance<T>();
                foreach (PropertyInfo propInfo in controlProperties)
                {
                    if (propInfo.CanWrite)
                    {
                        if (propInfo.Name != "WindowTarget")
                            propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                    }
                }
                return instance;
            }
        }
    }
