    EventMask valueChangedEventMask;
    // In the class constructor
    valueChangedEventMask = new EventMask(
        () => { dgv.CellValueChanged += new DataGridViewCellEventHandler(dgv_CellValueChanged); },
        () => { dgv.CellValueChanged -= new DataGridViewCellEventHandler(dgv_CellValueChanged); }
    );
    // The value change operation I want to hide from the event
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
