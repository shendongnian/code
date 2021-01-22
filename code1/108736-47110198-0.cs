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
    
        public partial class RadioButton : Button
        {
            //Override OnClick event. - THIS IS WHERE ALL THE WORK IS DONE
            protected override void OnClick(EventArgs e)
            {
                do
                {
                    /*
                        This is where you select current RadioButton. 
                        I'm changing the BackColor for simplicity. 
                    */
                    this.BackColor = System.Drawing.Color.Green;
    
                    /*
                       If parent of current RadioButton is null, 
                       then it doesn't belong in a group.
                    */
                    if (this.Parent == null)
                        break;
    
                    /*
                        Else loop through all other RadioButton of the same group and clear them. 
                        Include System.Linq for this part.
                    */
                    foreach (RadioButton button in this.Parent.Controls.OfType<RadioButton>())
                    {
                        //If button equals to current RadioButton, continue to the next RadioButton
                        if (button == this)
                            continue;
    
                        //This is where you clear other RadioButtons
                        button.BackColor = System.Drawing.Color.Red;
                    }
                }
                while (false);
    
                //Continue with the regural OnClick event.
                base.OnClick(e);
            }
        }
    }
