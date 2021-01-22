    		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.SuspendLayout();
				base.OnLoad(e);
				foreach (Control ctrl in Controls)
				{
					Button btn = ctrl as Button;
					if (btn == null) continue;
					if (string.Equals(btn.Name, "btnAdd", StringComparison.Ordinal))
						btn.Click += new EventHandler(btnAdd_Click);
					else if (string.Equals(btn.Name, "btnEdit", StringComparison.Ordinal))
						btn.Click += new EventHandler(btnEdit_Click);
					else if (string.Equals(btn.Name, "btnDelete", StringComparison.Ordinal))
						btn.Click += new EventHandler(btnDelete_Click);
					else if (string.Equals(btn.Name, "btnPrint", StringComparison.Ordinal))
						btn.Click += new EventHandler(btnPrint_Click);
					else if (string.Equals(btn.Name, "btnExport", StringComparison.Ordinal))
						btn.Click += new EventHandler(btnExport_Click);
				}
