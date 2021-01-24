	private async void ButtonMRCUpdateAllExcelSheetsClick(object sender, EventArgs e) {
		cmdMRCUpdateAllExcelSheets.Enabled = false;
		cmdMRCUpdateSingleClient.Enabled = false;
		tsStatusBar.Value = 0;
		tsStatusBar.Visible = true;
		DateTime YearAndMonth = new DateTime(dtpMRC.Value.Year, dtpMRC.Value.Month, 1);
		List<string> List = new List<string>();
		using (wotcDB DB = new wotcDB()) {
			var r = DB.client_main.
				Where(t => t.Active == true).
				OrderBy(t => t.CLIENTCODE).
				Select(t => t.CLIENTCODE);
			List.AddRange(await r.ToArrayAsync());
			tsStatusBar.Maximum = List.Count;
			foreach (var Client in List) {
				await Task.Run(() => {
					DB.system_MRC(Client, YearAndMonth);
				});
				tsStatusBar.Value++;
			}
		}
		cmdMRCUpdateAllExcelSheets.Enabled = true;
		cmdMRCUpdateSingleClient.Enabled = true;
		tsStatusBar.Visible = false;
		tsStatusBar.Value = 0;
		MessageBox.Show("Monthly Results and Changes - Task Complete");
	}
