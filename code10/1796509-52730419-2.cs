    private void timer1_Tick( object sender, EventArgs e ) {
        Rectangle playerClone = player.Bounds; // new Rectangle( player.Left, player.Top, player.Width, player.Height );
        List<int> list = new List<int>();
            
        if( left == true ) {
            playerClone.X -= 5;
            int pos = GetIntersectPosL( playerClone );
            if( pos >= 0 ) { //there is a colision
                playerClone.X = pos;
            }
        }
        else if( right == true ) {
            playerClone.X += 5;
            int pos = GetIntersectPosR( playerClone );
            if( pos >= 0 ) { //there is a colision
                playerClone.X = pos - playerClone.Width;
            }
        }
        if( jump == true ) {
            //Falling (if the player has jumped before)
            playerClone.Y -= (Force - 5); //the 5 is from falling.
            if( Force - 5 >= 0 ) { //going up
                int pos = GetIntersectPosU( playerClone );
                if( pos >= 0 ) {
                    playerClone.Y = pos;
                }
            }
            else { //Falling down
                int pos = GetIntersectPosD( playerClone );
                if( pos >= 0 ) {
                    playerClone.Y = pos - playerClone.Height;
                    jump = false;
                }
            }
                
            Force -= 1;
        }
        else { //Falling without previous jumping
            playerClone.Y += 5;
            int pos = GetIntersectPosD( playerClone );
            if( pos >= 0 ) {
                playerClone.Y = pos - playerClone.Height;
            }
        }
        player.Bounds = playerClone;
    }
    private int GetIntersectPosL(Rectangle src) {
        List<int> list = new List<int>();
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
