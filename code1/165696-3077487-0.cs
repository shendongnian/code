    private void DeleteAll( FlowLayoutPanel flp)
    {
        var UnlockedImages = GetAllList(flp).Except(GetLockedList(flp));
        flp.SuspendLayout();
    
        foreach (ImageControl ic in UnlockedImages)
        {
            flp.Controls.Remove(ic);
        }
    
        flp.ResumeLayout();
    }
