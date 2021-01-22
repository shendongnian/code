    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace NoCloseContextMenu
    {
        public partial class Form1 : Form
        {
            bool[] store_checks = new bool[8];
    
            public Form1()
            {
                InitializeComponent();
                richTextBox1.AppendText("http://");
                richTextBox1.LinkClicked += new LinkClickedEventHandler(richTextBox1_LinkClicked);
            }
    
            void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
            {
                ToolStripMenuItem[] inner_menuitems = new ToolStripMenuItem[8];
                for (int i = 0; i < store_checks.Length; i++)
                {
                    ToolStripMenuItem inner_menuitem = new ToolStripMenuItem("Check #" + i.ToString());
                    inner_menuitem.Checked = store_checks[i];
                    inner_menuitem.CheckOnClick = true;
                    inner_menuitem.ShortcutKeys = Keys.Control | (Keys)(48 + i); //Di = 48 + i
                    inner_menuitem.ShowShortcutKeys = true;
                    inner_menuitem.Click += new EventHandler(inner_menuitem_Click);
                    inner_menuitem.Tag = i.ToString();
                    inner_menuitems[i] = inner_menuitem;
                }
                ToolStripMenuItem outer_menu = new ToolStripMenuItem("Outer Menu", null, inner_menuitems);
                outer_menu.DropDown.Closing += new ToolStripDropDownClosingEventHandler(DropDown_Closing);
                ContextMenuStrip context_menu = new ContextMenuStrip();
                context_menu.Items.Add(outer_menu);
                context_menu.Show(this, this.PointToClient(Cursor.Position));
            }
    
            void DropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
            {
                if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                {
                    e.Cancel = true;
                    ((ToolStripDropDownMenu)sender).Invalidate();
                }
            }
    
            void inner_menuitem_Click(object sender, EventArgs e)
            {
                ToolStripMenuItem sender_menu = (ToolStripMenuItem)sender;
                int index = int.Parse(sender_menu.Tag.ToString());
                store_checks[index] = !store_checks[index];
            }
    
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
    
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.richTextBox1 = new System.Windows.Forms.RichTextBox();
                this.SuspendLayout();
                //
                // richTextBox1
                //
                this.richTextBox1.Location = new System.Drawing.Point(13, 13);
                this.richTextBox1.Name = "richTextBox1";
                this.richTextBox1.Size = new System.Drawing.Size(100, 96);
                this.richTextBox1.TabIndex = 0;
                this.richTextBox1.Text = "";
                //
                // Form1
                //
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.richTextBox1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
            }
    
            #endregion
    
            private System.Windows.Forms.RichTextBox richTextBox1;
        }
    }
