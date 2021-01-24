	public WebpageLocalScanner()
	{
		InitializeComponent();
		InitializeListView();
	}
	internal string GetType(string ip, int port)
	{
		try
		{
			if (port == 1234 || port == 4321)
			{
				string urlAddress = string.Format("http://{0}", ip);
				string text = this.GetHttpData(ip, 80, urlAddress, 5120).ToUpper();
				if (text.Contains("<HTML>"))
				{
					return "Webpage is here";
				}
			}
		}
		catch (Exception)
		{
		}
		return string.Empty;
	}
	public async void AddItem() {
			listView1.Items.Clear();
			int froms192 = Convert.ToInt32(tB1.Text);
			int froms168 = Convert.ToInt32(tB2.Text);
			int froms1a = Convert.ToInt32(tB3.Text);
			int froms1b = Convert.ToInt32(tB4.Text);
			int fromports = Convert.ToInt32(tBp1.Text);
			int toports = Convert.ToInt32(tBp2.Text);
			string FromIP = froms192 + "." + froms168 + "." + froms1a + "." + froms1b;
			int FromPort = fromports;
			int ToPort = toports;
			int tos192 = Convert.ToInt32(tB5.Text);
			int tos168 = Convert.ToInt32(tB6.Text);
			int tos1a = Convert.ToInt32(tB7.Text);
			int tos1b = Convert.ToInt32(tB8.Text);
			string ToIP = froms192 + "." + froms168 + "." + froms1a + "." + froms1b;
			if (froms1a < tos1a || froms1b < tos1b)
			{
				var listViewItems = new List<ListViewItem>();
				await Task.Run(() => {
					for (int i = froms1b; i <= tos1b; i++)
					{
						List<string[]> rows = new List<string[]>();
						for (int u = froms1a; u <= tos1a; u++)
						{   
							for (int p = fromports; p <= toports; p++)
							{
								string GenIP = froms192 + "." + froms168 + "." + u + "." + i;
								string result = GetType(GenIP, p);
								if (result != null) {
									string[] row = { Convert.ToString(GenIP), Convert.ToString(fromports), Convert.ToString(result), Convert.ToString(tos1a), Convert.ToString(tos1a) };
									rows.add(row);
									
								};
							}
						}
					}
				});
				listView1.Items.AddRange(rows.Select(a => new ListViewItem(a)).ToArray());
			}
	}
	private void InitializeListView()
	{
		// Set the view to show details.
		listView1.View = View.Details;
		// Allow the user to edit item text.
		listView1.LabelEdit = true;
		// Allow the user to rearrange columns.
		listView1.AllowColumnReorder = true;
		// Display check boxes.
		// listView1.CheckBoxes = true;
		// Select the item and subitems when selection is made.
		listView1.FullRowSelect = true;
		// Display grid lines.
		listView1.GridLines = true;
		// Sort the items in the list in ascending order.
		listView1.Sorting = SortOrder.Ascending;
		// Attach Subitems to the ListView
		listView1.Columns.Add("IP", 100, HorizontalAlignment.Left);
		listView1.Columns.Add("PORT", 50, HorizontalAlignment.Left);
		listView1.Columns.Add("SERVER", 100, HorizontalAlignment.Left);
		listView1.Columns.Add("TYPE", 100, HorizontalAlignment.Left);
		listView1.Columns.Add("COMMENT", 100, HorizontalAlignment.Left);            
	}
	private async void button1_Click(object sender, EventArgs e)
	{
		AddItem();
	}
