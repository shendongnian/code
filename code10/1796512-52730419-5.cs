    private void timer1_Tick( object sender, EventArgs e ) {
        Rectangle playerClone = player.Bounds; // new Rectangle( player.Left, player.Top, player.Width, player.Height );
        List<int> list = new List<int>();
            
        if( left == true ) {
            playerClone.X -= 5;
 
            //Check if we have left colision
            int pos = GetIntersectPosL( playerClone );
            if( pos >= 0 ) { //there is a colision
                playerClone.X = pos;
            }
        }
        else if( right == true ) {
            playerClone.X += 5;
            //Check if we have right colision
            int pos = GetIntersectPosR( playerClone );
            if( pos >= 0 ) { //there is a colision
                playerClone.X = pos - playerClone.Width;
            }
        }
        if( jump == true ) {
            playerClone.Y -= (Force - 5); //the 5 is from falling.
            if( Force - 5 >= 0 ) { //going up
                //Check if we have up colision, if the top of the player is colliding with anything
                int pos = GetIntersectPosU( playerClone );
                if( pos >= 0 ) { //there is a colision
                    playerClone.Y = pos;
                }
            }
            else { //Falling down
                //Check if we have down colision, if the bottom of the player is colliding with anything
                int pos = GetIntersectPosD( playerClone );
                if( pos >= 0 ) { //there is a colision
                    playerClone.Y = pos - playerClone.Height;
                    jump = false;
                }
            }
                
            Force -= 1;
        }
        else { //Falling without previous jumping
            playerClone.Y += 5;
            
            //Check if we have down colision, if the bottom of the player is colliding with anything
            int pos = GetIntersectPosD( playerClone );
            if( pos >= 0 ) { //there is a colision
                playerClone.Y = pos - playerClone.Height;
            }
        }
        player.Bounds = playerClone;
    }
    private int GetIntersectPosL(Rectangle src) {
        List<int> list = new List<int>();
        
        //Get all intersect rectangles and add the right side to the list
        for( int i = 0; i < obstacles.Count; i++ ) {
            if( src.IntersectsWith( obstacles[ i ] ) == true ) {
                list.Add( obstacles[ i ].Right );
            }
        }
        if( list.Count == 0 ) { //no intersect
            return -1;
        }
        return list.Max();
    }
    private int GetIntersectPosR( Rectangle src ) {
        List<int> list = new List<int>();
        //Get all intersect rectangles and add the left side to the list
        for( int i = 0; i < obstacles.Count; i++ ) {
            if( src.IntersectsWith( obstacles[ i ] ) == true ) {
                list.Add( obstacles[ i ].Left );
            }
        }
        if( list.Count == 0 ) { //No intersect
            return -1;
        }
        return list.Min();
    }
    private int GetIntersectPosD( Rectangle src ) {
        List<int> list = new List<int>();
        //Get all intersect rectangles and add the top side to the list
        for( int i = 0; i < obstacles.Count; i++ ) {
            if( src.IntersectsWith( obstacles[ i ] ) == true ) {
                list.Add( obstacles[ i ].Top );
            }
        }
        if( list.Count == 0 ) { //No intersect
            return -1;
        }
        return list.Min();
    }
    private int GetIntersectPosU( Rectangle src ) {
        List<int> list = new List<int>();
        //Get all intersect rectangles and add the bottom side to the list
        for( int i = 0; i < obstacles.Count; i++ ) {
            if( src.IntersectsWith( obstacles[ i ] ) == true ) {
                list.Add( obstacles[ i ].Bottom );
            }
        }
        if( list.Count == 0 ) { //No intersect
            return -1;
        }
        return list.Max();
    }
