    namespace Utils.GUI
    {
        partial class InfoProgressBar
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
                if(disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Component Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.lblText = new Utils.GUI.TransparentLabel();
                this.SuspendLayout();
                // 
                // lblText
                // 
                this.lblText.BackColor = System.Drawing.Color.Transparent;
                this.lblText.Dock = System.Windows.Forms.DockStyle.Fill;
                this.lblText.Location = new System.Drawing.Point(0, 0);
                this.lblText.Name = "lblText";
                this.lblText.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
                this.lblText.Size = new System.Drawing.Size(100, 23);
                this.lblText.TabIndex = 0;
                this.lblText.Text = "transparentLabel1";
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private TransparentLabel lblText;
    
        }
    }
