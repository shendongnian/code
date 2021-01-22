    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            List<Item> items; 
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {   
                //Let's say we are getting items from two different datasources and putting them in a same collection 
                items = new List<Item>();
                //Getting pens from dataSource1
                items.Add (new Pen("Parker",Color.Blue ));
                items.Add(new Pen("Paper Mate", Color.Blue));
                //Adding Books from dataSource2
                items.Add(new Book("Programming in C", Color.Red));
                items.Add(new Book("Design Patterns", Color.Red));
                //Data binding 
                comboBox1.DataSource = items;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Color";
                this.comboBox1.DrawMode = DrawMode.OwnerDrawFixed; //Do not forget this
            }
    
            private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
            {
                e.DrawBackground();
                int index = e.Index;
                Item   item = comboBox1.Items[index] as Item  ;
                if (item.Color.Equals ( Color.Red)) 
                    e.Graphics.DrawString(item.Name, this.Font , Brushes.Red, new Point(e.Bounds.X, e.Bounds.Y));
                else if  (item.Color.Equals ( Color.Blue))
                    e.Graphics.DrawString(item.Name, this.Font, Brushes.Blue, new Point(e.Bounds.X, e.Bounds.Y));
                else
                    e.Graphics.DrawString(item.Name, this.Font, Brushes.Black, new Point(e.Bounds.X, e.Bounds.Y));
            }
        }
    
        public abstract class  Item
        {
            string name;
            Color  color;
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
    
            public Color Color
            {
                get
                {
                    return color;
                }
                set
                {
                    color = value;
                }
            }
        }
    
        public class Book:Item  
        {
            public Book(string name, Color color){
                this.Name  = name;
                this.Color = color; 
            }
        }
    
        public class Pen : Item  
        {
            public Pen(string name, Color color){
                this.Name  = name;
                this.Color  = color; 
            }
        }
    }
