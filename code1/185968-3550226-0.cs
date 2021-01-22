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
            string invariant = "iii".ToUpperInvariant();
            CultureInfo turkey = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = turkey;
            string cultured = "iii".ToUpper();
            
            Font bigFont = new Font("Arial", 40);
            Form f = new Form {
                Controls = {
                    new Label { Text = invariant, Location = new Point(20, 20),
                                Font = bigFont, AutoSize = true},
                    new Label { Text = cultured, Location = new Point(20, 100),
                                Font = bigFont, AutoSize = true }
                }
            };        
            Application.Run(f);
        }
    }
