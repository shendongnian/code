    private void InitializeComponent()
    {
        this.button1 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.BackColor = System.Drawing.Color.Black;
        this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.button1.Font = new System.Drawing.Font("Arial", 12F, 
        System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 
        ((byte)(0)));
        this.button1.ForeColor = System.Drawing.Color.Gray;
        this.button1.Location = new System.Drawing.Point(0, 0);
        this.button1.Name = "button1";
        this.button1.AutoSize = true;  //you were missing this for the button
        this.button1.Size = new System.Drawing.Size(27, 26);
        this.button1.TabIndex = 0;
        this.button1.Text = "X";
        this.button1.UseVisualStyleBackColor = false;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.AutoSize = true;  //you were missing this for the form
        this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;//also this 
        this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
        this.ClientSize = new System.Drawing.Size(40, 40);
        this.Controls.Add(this.button1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.ResumeLayout(false);
    }
