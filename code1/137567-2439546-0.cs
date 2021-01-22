    // Add code
            DataRowView selected = listBox1.SelectedItem as DataRowView;
            if (selected != null)
            {
                _myList.Add(selected); // Adds at end
                BindList2();
            }
    
    // Move up code
        int selectedIndex = listBox2.SelectedIndex;
        if(selectedIndex > 0)
        {
            var temp = _myList[selectedIndex];
            _myList.Remove(temp);
            _myList.InsertAt(selectedIndex - 1, temp);
            BindList2();
        }
    
    // BindList2
    public void BindList2()
    {
        listBox2.DataSource = _myList;
        listBox2.DataBind();
    }
