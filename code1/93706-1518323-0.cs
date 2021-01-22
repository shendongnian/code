    using System;
    using System.Drawing;
    
    class Example
    {
    	static void Main()
    	{
    		String fontName = "Tahoma, Regular, Size";
    		String[] fontNameFields = fontName.Split(',');
    
    		Font font = new Font(fontNameFields[0],
    			Single.Parse(fontNameFields[2]),
    			(FontStyle)Enum.Parse(typeof(FontStyle), fontNameFields[1]));
    	}
    }
