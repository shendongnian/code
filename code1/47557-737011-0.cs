    for (int i = this.Controls.Count - 1; i >= 0; i--)
    {
        if (this.Controls[i].Name.Length == 2)
        {
            this.Controls.RemoveAt(i);
        }
    }
