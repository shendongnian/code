				int result;
				if (int.TryParse(value, out result))
					_buttonText = (result * 2).ToString();
				else
					_buttonText = value;
				this.Notify(() => ButtonText);
			}
		}
		private string _buttonText;
