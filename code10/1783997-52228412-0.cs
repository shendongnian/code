    private void GlobalVariables_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                switch (e.PropertyName)
                {
                    case nameof(GlobalVariables.FilePath):
                        NotifyPropertyChanged(nameof(TextBoxFilePath));
                        Frame.Navigate(this.GetType());
                        break;
                    case nameof(GlobalVariables.FileName):
                        NotifyPropertyChanged(nameof(TextBoxFileName));
                        Frame.Navigate(this.GetType());
                        break;
                }
            }
