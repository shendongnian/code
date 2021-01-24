    interface IControl
    {
    	void Paint();
    }
    class Control: IControl
    {
    	public void Paint() {...}
    }
    class TextBox: Control
    {
    	new public void Paint() {...}
    }
