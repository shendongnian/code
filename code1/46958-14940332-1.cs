    EventMask valueChangedEventMask;
    // In the class constructor
    valueChangedEventMask = new EventMask(
        () => { dgv.CellValueChanged += new DataGridViewCellEventHandler(dgv_CellValueChanged); },
        () => { dgv.CellValueChanged -= new DataGridViewCellEventHandler(dgv_CellValueChanged); }
    );
    // Use push to hide the event and pop to make it available again. The operation can be nested or be used in the event itself.
    void changeCellOperation()
    {
        valueChangedEventMask.Push();
    
        ...
        cell.Value = myNewCellValue
        ...
    
        valueChangedEventMask.Pop();
    }
    
    // The class
    public class EventMask
    {
        Action hook;
        Action unHook;
    
        int count = 0;
    
        public EventMask(Action hook, Action unHook)
        {
            this.hook = hook;
            this.unHook = unHook;
        }
    
        public void Push()
        {
            count++;
            if (count == 1)
                unHook();
        }
    
        public void Pop()
        {
            count--;
            if (count == 0)
                hook();
        }
    }
