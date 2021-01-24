    class xyz{
        private Color[] myColors = new Color[]{ Color.Red, Color.Blue, Color.Green }
        private int colorIndex = 0;
    
        // BackColor also declared somewhere here ...
    
        private void clickHandler( object sender, EventArgs e )
        {
             colorIndex = (++colorIndex)%myColors.length; 
             // ++ColorIndex is short for colorIndex = colorIndex + 1
             // % - "Remainder" => when colorIndex is 3 then 3 % 3 ( Remainder of 3 / 3 ) = 0
             // So this will increment on each click and "reset to 0" on 3, so you stay in bounds.
             BackColor = myColors[ colorIndex ];
        }
    }
