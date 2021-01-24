	namespace ObjectListView_TreeListView
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
				this.xenSnapshotsTreeListView1 = new ObjectListView_TreeListView.FooTreeListView();
				this.olvColumnAction = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
				this.olvColumnNumbSsToKeep = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
				((System.ComponentModel.ISupportInitialize)(this.xenSnapshotsTreeListView1)).BeginInit();
				this.SuspendLayout();
				// 
				// xenSnapshotsTreeListView1
				// 
				this.xenSnapshotsTreeListView1.AllColumns.Add(this.olvColumnAction);
				this.xenSnapshotsTreeListView1.AllColumns.Add(this.olvColumnNumbSsToKeep);
				this.xenSnapshotsTreeListView1.CellEditUseWholeCell = false;
				this.xenSnapshotsTreeListView1.CheckBoxes = true;
				this.xenSnapshotsTreeListView1.CheckedAspectName = "IsChecked";
				this.xenSnapshotsTreeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
				this.olvColumnAction,
				this.olvColumnNumbSsToKeep});
				this.xenSnapshotsTreeListView1.Cursor = System.Windows.Forms.Cursors.Default;
				this.xenSnapshotsTreeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
				this.xenSnapshotsTreeListView1.GridLines = true;
				this.xenSnapshotsTreeListView1.Location = new System.Drawing.Point(0, 0);
				this.xenSnapshotsTreeListView1.MultiSelect = false;
				this.xenSnapshotsTreeListView1.Name = "xenSnapshotsTreeListView1";
				this.xenSnapshotsTreeListView1.ShowGroups = false;
				this.xenSnapshotsTreeListView1.ShowImagesOnSubItems = true;
				this.xenSnapshotsTreeListView1.Size = new System.Drawing.Size(800, 450);
				this.xenSnapshotsTreeListView1.TabIndex = 0;
				this.xenSnapshotsTreeListView1.UseAlternatingBackColors = true;
				this.xenSnapshotsTreeListView1.UseCompatibleStateImageBehavior = false;
				this.xenSnapshotsTreeListView1.View = System.Windows.Forms.View.Details;
				this.xenSnapshotsTreeListView1.VirtualMode = true;
				// 
				// olvColumnAction
				// 
				this.olvColumnAction.AspectName = "Action";
				this.olvColumnAction.Text = "Action";
				this.olvColumnAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
				this.olvColumnAction.Width = 200;
				// 
				// olvColumnNumbSsToKeep
				// 
				this.olvColumnNumbSsToKeep.AspectName = "NumberToKeep";
				this.olvColumnNumbSsToKeep.Text = "# To Keep";
				this.olvColumnNumbSsToKeep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				this.olvColumnNumbSsToKeep.Width = 65;
				// 
				// Form1
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(800, 450);
				this.Controls.Add(this.xenSnapshotsTreeListView1);
				this.Name = "Form1";
				this.Text = "Form1";
				((System.ComponentModel.ISupportInitialize)(this.xenSnapshotsTreeListView1)).EndInit();
				this.ResumeLayout(false);
			}
			#endregion
			private FooTreeListView xenSnapshotsTreeListView1;
			private BrightIdeasSoftware.OLVColumn olvColumnAction;
			private BrightIdeasSoftware.OLVColumn olvColumnNumbSsToKeep;
		}
	}
