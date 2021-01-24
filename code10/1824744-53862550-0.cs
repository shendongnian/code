    void Main()
    {
    	var input = @"id  score ping guid       name            lastmsg address               qport  rate
    -- - -------------------------------------------------------------------------
      1     11  45 176387877  Player 1        3250    101.102.103.104:555   3647   25000
      2     23  61 425716719  Player 2        3250    105.106.107.108:555   5978   25000";
    
        //Gets you each line
    	var lines = input.Split('\n');
    
    	foreach (var line in lines)
    	{
          // For each line, Regex split will return an array with each entry
          // Set a breakpoint with the debugger and inspect to see what I mean.
          // Splits using regex - assumes at least 2 spaces between items 
          // so space in 'Player 1' is handled it's a fickle solution though
          // Trim the line before RegEx split to avoid extra data in the split
           var r = Regex.Split(line.Trim(), @"\s{2,}"); 
    	}
    }
