    var users = new ObservableCollection<User>();
    
                private void Add()
                {
                    try
                    {
                        int age = 0;
                        if (int.TryParse(agetextBox.Text.ToString(), out int parsedAge))
                        {
                            age = parsedAge;
                        }
    
                        users.Add(new User
                        {
                            Name = nametextBox.Text,
                            Surname = surnametextBox.Text,
                            Age = age,
                            Branch = branchcomboBox.SelectedItem.ToString()
                        };
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
