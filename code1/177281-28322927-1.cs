    private void listbox1_Drop(object sender, DragEventArgs e)
    {
        if (sender is ListBoxItem)
        {
            Emp droppedData = e.Data.GetData(typeof(Emp)) as Emp;
            Emp target = ((ListBoxItem)(sender)).DataContext as Emp;
            int removedIdx = listbox1.Items.IndexOf(droppedData);
            int targetIdx = listbox1.Items.IndexOf(target);
            if (removedIdx < targetIdx)
            {
                _empList.Insert(targetIdx + 1, droppedData);
                _empList.RemoveAt(removedIdx);
            }
            else
            {
                int remIdx = removedIdx + 1;
                if (_empList.Count + 1 > remIdx)
                {
                    _empList.Insert(targetIdx, droppedData);
                    _empList.RemoveAt(remIdx);
                }
            }
        }
    }
