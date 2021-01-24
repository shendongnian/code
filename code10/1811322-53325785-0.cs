    try
    {
        if(Position < 0 || Position > 8) 
        { 
             throw new BadMoveException(// Enter parameter here if you have any);
        }
        else
        {
             // Your code here
        }
    }
    catch(BadMoveException bmex) { // Show message here }
    catch(Exception ex) { // Show other exception }
