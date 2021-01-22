    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TabPageExample
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void mAddTabButton_Click(object sender, EventArgs e)
            {
                TabPage new_tab_page = new TabPage();
                if (!mTabNameTextBox.Text.Equals(""))
                {
                    new_tab_page.Text = mTabNameTextBox.Text;
                    new_tab_page.Name = mTabNameTextBox.Text;
                    mTabControl.TabPages.Add(new_tab_page);
                    mTabNameTextBox.Text = "";
                }
            }
    
            private void mRemoveTabButton_Click(object sender, EventArgs e)
            {
                if (mTabControl.TabPages.Count > 0)
                {
                    TabPage tab_page = mTabControl.TabPages[mTabNameTextBox.Text];
                    if (tab_page != null)
                    {
                        mTabControl.TabPages.Remove(tab_page);
                    }
                }
                mTabNameTextBox.Text = "";
            }
        }
    }
