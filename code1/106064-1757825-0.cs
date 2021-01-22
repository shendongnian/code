    private int NativeAdd(object item)
    {
        int num = (int) base.SendMessage(0x180, 0, base.GetItemText(item));
        switch (num)
        {
            case -2:
                throw new OutOfMemoryException();
    
            case -1:
                throw new OutOfMemoryException(SR.GetString("ListBoxItemOverflow"));
        }
        return num;
    }
