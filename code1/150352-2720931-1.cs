    B.Items.Clear;
    foreach(object o in A.Items)
    {
         b.Items.Add(o);
    }
    b.Items.Remove(A.SelectedItem);
