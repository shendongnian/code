    OnPropertyChanged("SelectedCar");
                    if (_SelectedCar != null)
                    {
                        CarSelected(_SelectedCar);
                        MessagingCenter.Send(this, "Hi");
                    }
