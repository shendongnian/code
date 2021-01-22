    StringBuilder sb = new StringBuilder();
    foreach(var cb in checkBoxes)
    {
        if(cb.IsChecked){ sb.Append(cb.Name);sb.Append(';'); }
    }
