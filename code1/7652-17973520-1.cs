	partial class NumberedTextBox
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
		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.editBox = new WebTools.Controls.RichTextBoxEx();
			this.SuspendLayout();
			// 
			// editBox
			// 
			this.editBox.AcceptsTab = true;
			this.editBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.editBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.editBox.Location = new System.Drawing.Point(27, 3);
			this.editBox.Name = "editBox";
			this.editBox.ScrollPos = new System.Drawing.Point(0, 0);
			this.editBox.Size = new System.Drawing.Size(120, 115);
			this.editBox.TabIndex = 0;
			this.editBox.Text = "";
			this.editBox.WordWrap = false;
			this.editBox.TextChanged += new System.EventHandler(this.editBox_TextChanged);
			// 
			// NumberedTextBox
			// 
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.editBox);
			this.Name = "NumberedTextBox";
			this.Size = new System.Drawing.Size(150, 121);
			this.ResumeLayout(false);
		}
		private RichTextBoxEx editBox;
		#endregion
	}
