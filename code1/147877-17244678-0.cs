		private void DisableReportViewerExportExcel()
		{
			var toolStrip = this.ReportViewer.Controls.Find("toolStrip1", true)[0] as ToolStrip;
			if (toolStrip != null)
				foreach (var dropDownButton in toolStrip.Items.OfType<ToolStripDropDownButton>())
					dropDownButton.DropDownOpened += new EventHandler(dropDownButton_DropDownOpened);
		}
		void dropDownButton_DropDownOpened(object sender, EventArgs e)
		{
			if (sender is ToolStripDropDownButton)
			{
				var ddList = sender as ToolStripDropDownButton;
				foreach (var item in ddList.DropDownItems.OfType<ToolStripDropDownItem>())
					if (item.Text.Contains("Excel"))
						item.Enabled = false;
			}
		}
