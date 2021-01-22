    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.button = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // button
        // 
        this.button.Location = new System.Drawing.Point(1, 5);
        this.button.Name = "Button1";        
        this.button.Size = new System.Drawing.Size(20, 50);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.button); // This is important
        this.Name = "Form1";
        this.Size = new System.Drawing.Size(569, 394);
        this.ResumeLayout(false);
    }
    #endregion
    private System.Windows.Forms.Button button;
