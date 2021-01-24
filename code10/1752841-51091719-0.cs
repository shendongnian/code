    this.btnExample.Location = new System.Drawing.Point(62, 0);
    this.btnExample.Name = "btnExample";
    this.btnExample.Size = new System.Drawing.Size(75, 390);
    this.btnExample.TabIndex = 1;
    this.btnExample.Text = "Out of Bounds";
    this.btnExample.UseVisualStyleBackColor = true;
    this.panel1.Controls.Add(this.btnExample);
    this.panel1.Location = new System.Drawing.Point(0, 0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new System.Drawing.Size(270, 391); //the width must fit inside your user control and the height was arbitrary
    this.panel1.TabIndex = 2;
    this.Controls.Add(this.panel1);
    this.Controls.Add(this.scbMain);
    this.Name = "CtrlScroll";
    this.Size = new System.Drawing.Size(474, 300);
