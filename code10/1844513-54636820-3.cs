    private void InitializeComponent()
    {
        this.richTextBoxEx1 = new WindowsFormsApp1.RichTextBoxEx(); //<-- RichTextBoxEx gets initialized and ITS constructor and InitializeComponent gets called
        this.SuspendLayout();
        // 
        // richTextBoxEx1
        // 
        this.richTextBoxEx1.Location = new System.Drawing.Point(322, 106);
        this.richTextBoxEx1.Name = "richTextBoxEx1";
        this.richTextBoxEx1.Size = new System.Drawing.Size(100, 96);
        this.richTextBoxEx1.TabIndex = 0;
        this.richTextBoxEx1.Text = ""; //<-- Text Property gets reseted
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.richTextBoxEx1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.ResumeLayout(false);
    }
