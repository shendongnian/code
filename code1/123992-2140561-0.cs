    using System;
    using System.Windows.Forms;
    
    class Test
    {
        static void Main()
        {
            Form form = new Form
            {
                Controls =
                {
                    new Label
                    {
                        Text = "-> \u03a9 <-"
                    }
                }
            };
            Application.Run(form);
        }
    }
