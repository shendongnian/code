    class Program {
    	static void Main(string[] args) {
    		MyButtons buttonsVisible = MyButtons.Button1 | MyButtons.Button2;
    		buttonsVisible |= MyButtons.Button8;
    
    		byte buttonByte = (byte)buttonsVisible; // store this into database
    
    		buttonsVisible = (MyButtons)buttonByte; // retreive from database
    	}
    }
    
    [Flags]
    public enum MyButtons : byte {
    	Button1 = 1,
    	Button2 = 1 << 1,
    	Button3 = 1 << 2,
    	Button4 = 1 << 3,
    	Button5 = 1 << 4,
    	Button6 = 1 << 5,
    	Button7 = 1 << 6,
    	Button8 = 1 << 7
    } 
