    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    
    public class Test
    {
        [STAThread]
        static void Main()
        {
            string invariant = "iii".ToUpper(CultureInfo.InvariantCulture);
            string cultured = "iii".ToUpper(new CultureInfo("tr-TR"));
    
            Application.Run(new Form {
                Font = new Font("Times New Roman", 40),
                Controls = { 
                    new Label { Text = invariant, Location = new Point(20, 20), AutoSize = true }, 
                    new Label { Text = cultured, Location = new Point(20, 100), AutoSize = true }, 
                }
            });
        }
    }
