    public bool MyButtonEnabled
    {
		get
		{
			return anyButtonButNo_btLogin.Enabled;
		}
		set
		{
			foreach (Control ctrl in this.Controls)
			{
				if (ctrl.GetType() == typeof(Button) && ((Button)ctrl).Name != "btLogin")
				{
					((Button)ctrl).Enabled = value;
				}
			}
		}
    }
