        private void mainPanel_Drop(object sender, DragEventArgs e)
        {
            DataObject item = e.Data as DataObject;
            object listItem = item.GetData("DataContext") as IEnumerable<Member>;
            if (listItem != null)
            {
                foreach (Member member in (IEnumerable<Member>)listItem)
                {
                    ((ObservableCollection<Member>)mainPanel.DataContext).Add(member);
                }
                
            }
        }
