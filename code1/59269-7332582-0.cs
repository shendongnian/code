    using WUApiLib;
    protected override void OnLoad(EventArgs e){
        base.OnLoad(e);
        UpdateSession uSession = new UpdateSession();
        IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
		uSearcher.Online = false;
		try {
			ISearchResult sResult = uSearcher.Search("IsInstalled=1 And IsHidden=0");
			textBox1.Text = "Found " + sResult.Updates.Count + " updates" + Environment.NewLine;
			foreach (IUpdate update in sResult.Updates) {
					textBox1.AppendText(update.Title + Environment.NewLine);
			}
		}
		catch (Exception ex) {
			Console.WriteLine("Something went wrong: " + ex.Message);
		}
    }
