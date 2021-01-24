    private void loopPanel(List<Bug> list)
        {
             int x = 56;
             foreach (var bug in list)
             {//56
                //int x = 0;
                Panel panel = new Panel();
                this.panelBugs.Controls.Add(panel);
                Label lblProject = new Label();
                Label lblClass = new Label();
                Label lblMethod = new Label();
                PictureBox pictureBox = new PictureBox();
                //
                //panel
                //
                panel.BackColor = System.Drawing.Color.DarkOliveGreen;
                panel.Controls.Add(lblMethod);
                panel.Controls.Add(lblClass);
                panel.Controls.Add(lblProject);
                panel.Controls.Add(pictureBox);
                panel.Location = new System.Drawing.Point(10, x);
                x += 105;
                panel.Name = panel + bug.BugId.ToString();
                panel.Size = new System.Drawing.Size(535, 100);
                panel.TabIndex = 1;
                //panel.Paint += new System.Windows.Forms.PaintEventHandler(panel_Paint);
                panel.SuspendLayout();
                //
                //lblProject
                //
                lblProject.AutoSize = true;
                lblProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblProject.Location = new System.Drawing.Point(3, 3);
                lblProject.Name = lblProject + bug.BugId.ToString();
                lblProject.Size = new System.Drawing.Size(50, 16);
                lblProject.TabIndex = 1;
                lblProject.Text = "Project: "+ bug.ProjectName;
                //
                //lblClass
                //
                lblClass.AutoSize = true;
                lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblClass.Location = new System.Drawing.Point(3, 34);
                lblClass.Name = lblClass + bug.BugId.ToString();
                lblClass.Size = new System.Drawing.Size(42, 16);
                lblClass.TabIndex = 2;
                lblClass.Text = "Class: " + bug.ClassName;
                //
                //lblMethod
                //
                lblMethod.AutoSize = true;
                lblMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblMethod.Location = new System.Drawing.Point(4, 71);
                lblMethod.Name = lblMethod + bug.BugId.ToString();
                lblMethod.Size = new System.Drawing.Size(53, 16);
                lblMethod.TabIndex = 3;
                lblMethod.Text = "Method: " + bug.MethodName;
                //
                //pictureBox
                //
                pictureBox.Location = new System.Drawing.Point(391, 3);
                pictureBox.Name = pictureBox + bug.BugId.ToString();
                pictureBox.Size = new System.Drawing.Size(141, 94);
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                ((System.ComponentModel.ISupportInitialize)(pictureBox)).BeginInit();
                panel.ResumeLayout(false);
                panel.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(pictureBox)).EndInit();
            }
        }
