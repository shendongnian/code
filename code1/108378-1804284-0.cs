    namespace WindowsApplication10
    {
        /// <summary>
        /// This delegate will be used by the button 
        /// </summary>
        public delegate Point GetCenter();
    
        public partial class Form1 : Form
        {
            CentralButton central;
            public Form1()
            {
                InitializeComponent();
                central = new CentralButton(this.GetCenter);
                this.Controls.Add(central);
            }
    
            public Point GetCenter() 
            {
                return new Point(this.Width / 2, this.Height / 2);
            }
    
            protected override void OnSizeChanged(EventArgs e)
            {
                base.OnSizeChanged(e);
                central.UpdateCenter();
            }
        }
    
        /// <summary>
        /// This button calculates its location in the center of the parent
        /// </summary>
        public class CentralButton : Button 
        {
            GetCenter myGetCenterMethod;
            public CentralButton(GetCenter findCenterMethod)
            {
                myGetCenterMethod = findCenterMethod;
            }
    
            public void UpdateCenter()
            {
                // use the delegate for obtain the external information
                this.Location = myGetCenterMethod();
            }
        }
    }
