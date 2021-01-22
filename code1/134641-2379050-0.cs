        partial class FormMain
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
                this.buttonCancel = new System.Windows.Forms.Button();
                this.textBoxMessage = new System.Windows.Forms.TextBox();
                this.buttonOk = new System.Windows.Forms.Button();
                this.buttonDialogResult = new System.Windows.Forms.Button();
                this.buttonEvent = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // buttonCancel
                // 
                this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.buttonCancel.Location = new System.Drawing.Point(255, 138);
                this.buttonCancel.Name = "buttonCancel";
                this.buttonCancel.Size = new System.Drawing.Size(75, 23);
                this.buttonCancel.TabIndex = 4;
                this.buttonCancel.Text = "&Cancel";
                this.buttonCancel.UseVisualStyleBackColor = true;
                this.buttonCancel.Click += new System.EventHandler(this.OnButtonExitClick);
                // 
                // textBoxMessage
                // 
                this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.textBoxMessage.Location = new System.Drawing.Point(12, 12);
                this.textBoxMessage.Multiline = true;
                this.textBoxMessage.Name = "textBoxMessage";
                this.textBoxMessage.Size = new System.Drawing.Size(318, 120);
                this.textBoxMessage.TabIndex = 0;
                this.textBoxMessage.TextChanged += new System.EventHandler(this.OnTextChanged);
                // 
                // buttonOk
                // 
                this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
                this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.buttonOk.Location = new System.Drawing.Point(174, 138);
                this.buttonOk.Name = "buttonOk";
                this.buttonOk.Size = new System.Drawing.Size(75, 23);
                this.buttonOk.TabIndex = 3;
                this.buttonOk.Text = "&OK";
                this.buttonOk.UseVisualStyleBackColor = true;
                this.buttonOk.Click += new System.EventHandler(this.OnButtonExitClick);
                // 
                // buttonDialogResult
                // 
                this.buttonDialogResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.buttonDialogResult.Location = new System.Drawing.Point(12, 138);
                this.buttonDialogResult.Name = "buttonDialogResult";
                this.buttonDialogResult.Size = new System.Drawing.Size(75, 23);
                this.buttonDialogResult.TabIndex = 1;
                this.buttonDialogResult.Text = "by Result";
                this.buttonDialogResult.UseVisualStyleBackColor = true;
                this.buttonDialogResult.Click += new System.EventHandler(this.OnButtonResultClick);
                // 
                // buttonEvent
                // 
                this.buttonEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.buttonEvent.Location = new System.Drawing.Point(93, 138);
                this.buttonEvent.Name = "buttonEvent";
                this.buttonEvent.Size = new System.Drawing.Size(75, 23);
                this.buttonEvent.TabIndex = 2;
                this.buttonEvent.Text = "by Event";
                this.buttonEvent.UseVisualStyleBackColor = true;
                this.buttonEvent.Click += new System.EventHandler(this.OnButtonEventClick);
                // 
                // Form1
                // 
                this.AcceptButton = this.buttonOk;
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.CancelButton = this.buttonCancel;
                this.ClientSize = new System.Drawing.Size(342, 173);
                this.Controls.Add(this.buttonEvent);
                this.Controls.Add(this.buttonDialogResult);
                this.Controls.Add(this.buttonOk);
                this.Controls.Add(this.textBoxMessage);
                this.Controls.Add(this.buttonCancel);
                this.MinimumSize = new System.Drawing.Size(350, 200);
                this.Name = "Form1";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                this.Text = "My Dialog";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private System.Windows.Forms.Button buttonCancel;
            private System.Windows.Forms.TextBox textBoxMessage;
            private System.Windows.Forms.Button buttonOk;
            private System.Windows.Forms.Button buttonDialogResult;
            private System.Windows.Forms.Button buttonEvent;
        }
    }
