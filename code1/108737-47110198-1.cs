    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace StackOverflow
    {
        public partial class FormMain : Form
        {
            public FormMain()
            {
                InitializeComponent();
            }
        }
    
        public partial class MyRadioButton : Button
        {
            //Override OnClick event. - THIS IS WHERE ALL THE WORK IS DONE
            protected override void OnClick(EventArgs e)
            {
                do
                {
                    /*
                        This is where you select current MyRadioButton. 
                        I'm changing the BackColor for simplicity. 
                    */
                    this.BackColor = System.Drawing.Color.Green;
    
                    /*
                       If parent of current MyRadioButton is null, 
                       then it doesn't belong in a group.
                    */
                    if (this.Parent == null)
                        break;
    
                    /*
                        Else loop through all other MyRadioButton of the same group and clear them. 
                        Include System.Linq for this part.
                    */
                    foreach (MyRadioButton button in this.Parent.Controls.OfType<MyRadioButton>())
                    {
                        //If button equals to current MyRadioButton, continue to the next RadioButton
                        if (button == this)
                            continue;
    
                        //This is where you clear other MyRadioButton
                        button.BackColor = System.Drawing.Color.Red;
                    }
                }
                while (false);
    
                //Continue with the regular OnClick event.
                base.OnClick(e);
            }
        }
    }
