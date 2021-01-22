    string colorcode = "#FFFFFF00";    
    colorcode = colorcode.TrimStart('#');
    
    Color col; // from System.Drawing or System.Windows.Media
    if (colorcode.Length == 6)
    	col = Color.FromArgb(255, // hardcoded opaque
    				int.Parse(colorcode.Substring(0,2), NumberStyles.HexNumber),
    				int.Parse(colorcode.Substring(2,2), NumberStyles.HexNumber),
    				int.Parse(colorcode.Substring(4,2), NumberStyles.HexNumber));
    else // assuming length of 8
    	col = Color.FromArgb(
    				int.Parse(colorcode.Substring(0, 2), NumberStyles.HexNumber),
    				int.Parse(colorcode.Substring(2, 2), NumberStyles.HexNumber),
    				int.Parse(colorcode.Substring(4, 2), NumberStyles.HexNumber),
    				int.Parse(colorcode.Substring(6, 2), NumberStyles.HexNumber));
