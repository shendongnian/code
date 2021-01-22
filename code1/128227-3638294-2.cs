    procedure DrawGlassHeaderArea(g: Graphics; r: Rectangle; IsFormFocused: Boolean);
    const
       clFakeGlassColor = $00EAD1B9;  //(185, 209, 234) This is the fake foreground glass color (for use when composition is disabled)
       clFakeGlassColorUnfocused = $00F2E4D7; //(215, 228, 242) This is the fake background glass color (for use when composition is disabled)
    begin
       if Dwm.IsCompositionEnabled then
       begin
          g.FillRectangle(r, 0x00000000); //fill rectangle with transparent black
       end
       else
          //Composition disabled; fake it like Microsoft does
    
          //The color to use depends if the form has focused or not
          Color glassColor;
          if (IsFormFocused) then
             c = clFakeGlassColor 
          else
             c = clFakeGlassColorUnfocused;
    
          g.FillRectangle(r, glassColor); //fill rectangle with fake color
          //Now we have to draw the two accent lines along the bottom
          Color edgeHighlight = ColorBlend(Colors.White, glassColor, 0.33); //mix 33% of glass color to white
          Color edgeShadow = ColorBlend(Colors.Black, glassColor, 0.33); //mix 33% of glass color to black
          //Draw highlight as 2nd-last row:
          g.DrawLine(edgeHighlight, Point(r.Left, r.Bottom-2), Point(r.Right, r.Bottom-2);
          //Draw shadow on the very last row:
          g.DrawLine(edgeHighlight, Point(r.Left, r.Bottom-1), Point(r.Right, r.Bottom-1);
       end;
    end;
