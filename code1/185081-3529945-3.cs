    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Collections.Generic;
    
    namespace ProgressBarSample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                // Set our custom Style (% or text)
                customProgressBar1.DisplayStyle = ProgressBarDisplayText.CustomText;
                customProgressBar1.CustomText = "Initialising";
            }
    
            private void btnReset_Click(object sender, EventArgs e)
            {
                customProgressBar1.Value = 0;
                btnStart.Enabled = true;
            }
    
            private void btnStart_Click(object sender, EventArgs e)
            {
                btnReset.Enabled = false;
                btnStart.Enabled = false;
    
                for (int i = 0; i < 101; i++)
                {
    
                    customProgressBar1.Value = i;
                    // Demo purposes only
                    System.Threading.Thread.Sleep(100);
    
                    // Set the custom text at different intervals for demo purposes
                    if (i > 30 && i < 50)
                    {
                        customProgressBar1.CustomText = "Registering Account";
                    }
    
                    if (i > 80)
                    {
                        customProgressBar1.CustomText = "Processing almost complete!";
                    }
    
                    if (i >= 99)
                    {
                        customProgressBar1.CustomText = "Complete";
                    }
                }
                            
                btnReset.Enabled = true;
    
    
            }
    
       
        }
    }
