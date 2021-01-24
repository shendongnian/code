    public ListBox DragSource { get; set; }
    private void List_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var listBox = (ListBox) sender;
            if (listBox == null) return;
            DragSource = listBox;
            object data = GetDataFromListBox(DragSource, e.GetPosition(listBox));
            if (data != null)
                DragDrop.DoDragDrop(listBox, data, DragDropEffects.Move);
        }
