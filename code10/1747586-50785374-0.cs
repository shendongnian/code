    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Form_Application
    {
        public partial class Form1 : Form
        {
            //This is the constructor of the form
            public Form1()
            {
                //intializecomponent is used to construct the design of a form
                InitializeComponent();
                //it the method to start the timer
                this.timer1.Start();
            }
            //this is the event handler which is called when time of the timer is increased
            private void timer1_Tick(object sender, EventArgs e)
            {
                //check if progress bar value is less than 100
                if (progressBar1.Value < 100)
                {
                    //increase the value of progress bar by 1
                    this.progressBar1.Increment(1);
                }
    
                else {
                    //stop the timer when progress bar value is 100
                    timer1.Stop();
                    //get the image from the path
                    Image myImage = new Bitmap(@"C:\Users\user\source\repos\Form Application\Form Application\res\img1.png");
                    //set the image to the forms background here this represents the object of the form
                    this.BackgroundImage = myImage;
    
                }
            }
        }
    }
