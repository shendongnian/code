    namespace WindowsFormsApplication1
    {
        public partial class Component1 : Component
        {
            public Component1()
            {
                InitializeComponent();
            }
    
            public Component1(IContainer container)
            {
                container.Add(this);
    
                InitializeComponent();
            }
            bool bIsOn = true;
            public bool On
            {
                set 
             {
             bIsOn=value;
             
             if (bIsOn)
                 button1.Text = "ON";
             else 
                 button1.Text = "OFF";
    
             button1.Invalidate(); //force redrawing
            }
                
            }
            public void AddToForm(System.Windows.Forms.Form form)
            {
                form.Controls.Add(this.button1);
            }
        }
    }
    The main Form code : 
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                
                Component1 onOffButton = new Component1();
                
                onOffButton.On = true;
    
                onOffButton.AddToForm(this);
                
                
                
                
            }
        }
    }
