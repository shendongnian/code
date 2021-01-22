namespace STAFormWithThreadPoolSync
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
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.ThreadCount = new System.Windows.Forms.NumericUpDown();
			this.workersList = new System.Windows.Forms.ListView();
			this.WorkerProcessColumn = new System.Windows.Forms.ColumnHeader();
			this.ProgressTimer = new System.Windows.Forms.Timer(this.components);
			this.WorkersProgress = new System.Windows.Forms.ProgressBar();
			this.CurrentResultLabel = new System.Windows.Forms.Label();
			this.CurrentResult = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ThreadCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentResult)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(212, 19);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start threads";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// ThreadCount
			// 
			this.ThreadCount.Location = new System.Drawing.Point(23, 21);
			this.ThreadCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.ThreadCount.Name = "ThreadCount";
			this.ThreadCount.Size = new System.Drawing.Size(183, 20);
			this.ThreadCount.TabIndex = 1;
			this.ThreadCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// workersList
			// 
			this.workersList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.WorkerProcessColumn});
			this.workersList.Location = new System.Drawing.Point(23, 80);
			this.workersList.Name = "workersList";
			this.workersList.Size = new System.Drawing.Size(486, 255);
			this.workersList.TabIndex = 3;
			this.workersList.UseCompatibleStateImageBehavior = false;
			this.workersList.View = System.Windows.Forms.View.Details;
			// 
			// WorkerProcessColumn
			// 
			this.WorkerProcessColumn.Text = "Worker process";
			this.WorkerProcessColumn.Width = 482;
			// 
			// ProgressTimer
			// 
			this.ProgressTimer.Interval = 200;
			this.ProgressTimer.Tick += new System.EventHandler(this.ProgressTimer_Tick);
			// 
			// WorkersProgress
			// 
			this.WorkersProgress.Location = new System.Drawing.Point(112, 341);
			this.WorkersProgress.Name = "WorkersProgress";
			this.WorkersProgress.Size = new System.Drawing.Size(397, 24);
			this.WorkersProgress.TabIndex = 4;
			// 
			// CurrentResultLabel
			// 
			this.CurrentResultLabel.AutoSize = true;
			this.CurrentResultLabel.Location = new System.Drawing.Point(578, 266);
			this.CurrentResultLabel.Name = "CurrentResultLabel";
			this.CurrentResultLabel.Size = new System.Drawing.Size(74, 13);
			this.CurrentResultLabel.TabIndex = 5;
			this.CurrentResultLabel.Text = "Current Result";
			// 
			// CurrentResult
			// 
			this.CurrentResult.Location = new System.Drawing.Point(581, 282);
			this.CurrentResult.Maximum = new decimal(new int[] {
            -1593835520,
            466537709,
            54210,
            0});
			this.CurrentResult.Name = "CurrentResult";
			this.CurrentResult.ReadOnly = true;
			this.CurrentResult.Size = new System.Drawing.Size(169, 20);
			this.CurrentResult.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 352);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(81, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "processing load";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(762, 377);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CurrentResult);
			this.Controls.Add(this.CurrentResultLabel);
			this.Controls.Add(this.WorkersProgress);
			this.Controls.Add(this.workersList);
			this.Controls.Add(this.ThreadCount);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.ThreadCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentResult)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		#endregion
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.NumericUpDown ThreadCount;
		private System.Windows.Forms.ListView workersList;
		private System.Windows.Forms.ColumnHeader WorkerProcessColumn;
		private System.Windows.Forms.Timer ProgressTimer;
		private System.Windows.Forms.ProgressBar WorkersProgress;
		private System.Windows.Forms.Label CurrentResultLabel;
		private System.Windows.Forms.NumericUpDown CurrentResult;
		private System.Windows.Forms.Label label2;
	}
}
