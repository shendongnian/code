    private void Button_Click(object sender, RoutedEventArgs e)
        {
            string editedIds = string.Empty;
            foreach(SampleEntity temp in tempEntities)
            {
                if(temp.IsViewPermission && temp.IsIssuePermission && temp.IsActive)
                {
                    SampleEntity entity = entities.Single(item => item.Id == temp.Id);
                    if (entity.IsIssuePermission == false)
                    {
                        editedIds += entity.Id + ", ";
                    }
                }
            }            
            string message = string.Format("Issue Permission(s): {0} have been unchecked. Do you wish to continue?", editedIds);
            MessageBoxResult dialogResult = MessageBox.Show(message, "WARNING", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                return;
            }
        }
