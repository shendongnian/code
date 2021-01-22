    public string ButtonText
		{
			get { return  _buttonText; }
			set
			{
				int result;
				if (int.TryParse(value, out result))
					_buttonText = (result * 2).ToString();
				else
					_buttonText = value;
				OnPropertyChanged("ButtonText");		
            }
		}
		private string _buttonText;
