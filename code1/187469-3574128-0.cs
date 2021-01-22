		/// <summary>
		/// Change language at runtime in the specified form
		/// </summary>
		internal static void SetLanguage(this Form form, CultureInfo lang)
		{
			//Set the language in the application
			System.Threading.Thread.CurrentThread.CurrentUICulture = lang;
			ComponentResourceManager resources = new ComponentResourceManager(form.GetType());
			ApplyResourceToControl(resources, form.MainMenuStrip, lang);
			ApplyResourceToControl(resources, form, lang);
			
			//resources.ApplyResources(form, "$this", lang);
			form.Text = resources.GetString("$this.Text", lang);
		}
		private static void ApplyResourceToControl(ComponentResourceManager resources, Control control, CultureInfo lang)
		{
			foreach (Control c in control.Controls)
			{
				ApplyResourceToControl(resources, c, lang);
				//resources.ApplyResources(c, c.Name, lang);
				string text = resources.GetString(c.Name+".Text", lang);
				if (text != null)
					c.Text = text;
			}
		}
		private static void ApplyResourceToControl(ComponentResourceManager resources, MenuStrip menu, CultureInfo lang)
		{
			foreach (ToolStripItem m in menu.Items)
			{
				//resources.ApplyResources(m, m.Name, lang);
				string text = resources.GetString(m.Name + ".Text", lang);
				if (text != null)
					m.Text = text;
			}
		}
