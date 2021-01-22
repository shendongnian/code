    private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
    {
        foreach (var change in e.Changes)
        {
            if (change.AddedLength > 0 && change.RemovedLength == 0)
            {
                if (change.AddedLength == 1)
                {
                    AddCharacter(textBox1.Text[change.Offset], change.Offset);
                }
                else
                {
                    AddString(textBox1.Text.Substring(change.Offset, change.AddedLength), change.Offset);  
                }
            }
            else if (change.AddedLength == 0 && change.RemovedLength > 0)
            {
                if (change.RemovedLength == 1)
                {
                    RemoveCharacter(change.Offset);
                }
                else
                {
                    RemoveString(change.Offset, change.RemovedLength + change.Offset);
                }
            }
            else if (change.AddedLength == 1 & change.RemovedLength == 1)
            {
                ReplaceCharacter(change.Offset, textBox1.Text[change.Offset]);
            }
            else
            {
                ReplaceString(change.Offset, change.Offset + change.RemovedLength, textBox1.Text.Substring(change.Offset, change.AddedLength));
            }
        }
    }
