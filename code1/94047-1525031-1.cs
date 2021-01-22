    namespace TabPageExample
    {
        partial class Form1
        {
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
                this.mTabControl = new System.Windows.Forms.TabControl();
                this.mAddTabButton = new System.Windows.Forms.Button();
                this.mRemoveTabButton = new System.Windows.Forms.Button();
                this.mTabNameTextBox = new System.Windows.Forms.TextBox();
                this.label1 = new System.Windows.Forms.Label();
                this.SuspendLayout();
                // 
                // mTabControl
                // 
                this.mTabControl.Location = new System.Drawing.Point(12, 12);
                this.mTabControl.Name = "mTabControl";
                this.mTabControl.SelectedIndex = 0;
                this.mTabControl.Size = new System.Drawing.Size(499, 379);
                this.mTabControl.TabIndex = 0;
                // 
                // mAddTabButton
                // 
                this.mAddTabButton.Location = new System.Drawing.Point(162, 408);
                this.mAddTabButton.Name = "mAddTabButton";
                this.mAddTabButton.Size = new System.Drawing.Size(75, 23);
                this.mAddTabButton.TabIndex = 1;
                this.mAddTabButton.Text = "Add Tab";
                this.mAddTabButton.UseVisualStyleBackColor = true;
                this.mAddTabButton.Click += new System.EventHandler(this.mAddTabButton_Click);
                // 
                // mRemoveTabButton
                // 
                this.mRemoveTabButton.Location = new System.Drawing.Point(243, 408);
                this.mRemoveTabButton.Name = "mRemoveTabButton";
                this.mRemoveTabButton.Size = new System.Drawing.Size(75, 23);
                this.mRemoveTabButton.TabIndex = 2;
                this.mRemoveTabButton.Text = "Remove Tab";
                this.mRemoveTabButton.UseVisualStyleBackColor = true;
                this.mRemoveTabButton.Click += new System.EventHandler(this.mRemoveTabButton_Click);
                // 
                // mTabNameTextBox
                // 
                this.mTabNameTextBox.Location = new System.Drawing.Point(194, 444);
                this.mTabNameTextBox.Name = "mTabNameTextBox";
                this.mTabNameTextBox.Size = new System.Drawing.Size(100, 20);
                this.mTabNameTextBox.TabIndex = 3;
                // 
                // label1
                // 
                this.label1.AutoSize = true;
                this.label1.Location = new System.Drawing.Point(30, 447);
                this.label1.Name = "label1";
                this.label1.Size = new System.Drawing.Size(158, 13);
                this.label1.TabIndex = 4;
                this.label1.Text = "Enter tab name to Add/Remove";
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(523, 476);
                this.Controls.Add(this.label1);
                this.Controls.Add(this.mTabNameTextBox);
                this.Controls.Add(this.mRemoveTabButton);
                this.Controls.Add(this.mAddTabButton);
                this.Controls.Add(this.mTabControl);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
    
            private System.Windows.Forms.TabControl mTabControl;
            private System.Windows.Forms.Button mAddTabButton;
            private System.Windows.Forms.Button mRemoveTabButton;
            private System.Windows.Forms.TextBox mTabNameTextBox;
            private System.Windows.Forms.Label label1;
        }
    }
