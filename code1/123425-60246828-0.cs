using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
public class Form1
{
    // give a variable as a TabPage here so we know which one is selected(in focus)
    private TabPage selectedPage = TabPage1;
    // If a key is pressed when the tab control has focus, it checks to see if it is the right tab page
    // and then show a message box(for demonstration)
    private void TabControl1_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        // The IF Not is to basically catch any odd happening that might occur if a key stroke gets passed with
        // no selected tab page
        if (!selectedPage == null)
        {
            // If the tabpage is TabPage2
            if (selectedPage.Name == "TabPage2")
                MessageBox.Show("Key Pressed");
        }
    }
    // This handles the actual chaning of the tab pages
    private void TabControl1_Selected(System.Object sender, System.Windows.Forms.TabControlEventArgs e)
    {
        selectedPage = TabControl1.SelectedTab;
    }
}
I hope this helps you :)
[1]: https://stackoverflow.com/a/2129010/12068778
