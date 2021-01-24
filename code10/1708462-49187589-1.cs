    private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(SampleEntity temp in tempEntities)
            {
                if(temp.IsViewPermission && temp.IsIssuePermission && temp.IsActive)
                {
                    if(entities.Single(entity => entity.Id == temp.Id).IsIssuePermission == false)
                    {
                        MessageBoxResult dialogResult = MessageBox.Show("Issue Permission is unchecked. Do you wish to continue? ", "WARNING", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                        }
                        else if (dialogResult == MessageBoxResult.No)
                        {
                            return;
                        }
                    }
                }
            }
        }
