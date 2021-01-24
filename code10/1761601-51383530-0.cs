    public partial class
	{
		int i = 0;
		List<Button> menuButtons = new List<Button>();
		Button selectedButton = new Button();
		public Menu()
		{
			InitializeComponent();
            //Assigning click events for the buttons.
			btnPlay.Click += BtnPlay_Click;
			btnOptions.Click += BtnOptions_Click;
			btnExit.Click += BtnExit_Click;
			menuButtons.Add(btnPlay);
			menuButtons.Add(btnOptions);
			menuButtons.Add(btnExit);
			selectedButton = menuButtons[i];
			if (menuButtons[i] == selectedButton)
			{
				menuButtons[i].FlatAppearance.BorderSize = 1;
			}
		}
		private void Menu_KeyDown(object sender, KeyEventArgs e)
		{
            //Removing border from previously selected button.
			menuButtons[i].FlatAppearance.BorderSize = 0; 
			if (e.KeyCode == Keys.Down)
			{
				if (i < menuButtons.Count)
				{
					i++;
				}
				else if (i >= menuButtons.Count)
				{
					i = 0;
				}
			}
			if (e.KeyCode == Keys.Up)
			{
				if (i > 0)
				{
					i--;
				}
				else if (i <= 0)
				{
					i = menuButtons.Count;
				}
			}
            //Setting border for the newly selected button.
			menuButtons[i].FlatAppearance.BorderSize = 1;
			if (e.KeyCode == Keys.Enter)
			{
				switch (i)
				{
					case 0:
						btnPlay.PerformClick();
						break;
					case 1:
						btnOptions.PerformClick();
						break;
					case 2:
						btnExit.PerformClick();
						break;
				}
			}
		}
		private void BtnExit_Click(object sender, EventArgs e)
		{
			//Code for the Exit button.
		}
		private void BtnOptions_Click(object sender, EventArgs e)
		{
			//Code for the Options button.
		}
		private void BtnPlay_Click(object sender, EventArgs e)
		{
			//Code for the Play button.
		}
	}
