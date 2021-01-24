    private void Add() {
        //Find empty space, pos is basically the free line to add button and textbox
        //each line is seperated by 24 pixels
        int pos = FindPosition();
        if(pos < 0) {
            return; //no space
        }
        TextBox txt = new TextBox() {
            Name = "timerBox" + Convert.ToString( pos ),
            Width = 63,
            Location = new Point( 0, pos * 24 )
        };
        Button delBtn = new Button() {
            Name = "delBtn" + Convert.ToString( pos ),
            Width = 20,
            Height = 20,
            Text = "X",
            Location = new Point( 67, pos * 24 ),
        };
        delBtn.Click += ( sender, e ) =>
        {
            Remove( ( (Button)sender ).Handle );
        };
        TimerContainer.Controls.Add( txt );
        TimerContainer.Controls.Add( delBtn );
        Node node;
        node.btn = delBtn;
        node.txt = txt;
        node.hwndTxtBox = txt.Handle;
        node.hwndBtn = delBtn.Handle;
        node.position = pos;
        node.timerLife = 300;
        list.Add(node);
    }
    private void Remove(IntPtr hwnd) {
        int i;
        //find element in list to remove
        for( i = 0; i < list.Count; i++ ) {
            if( hwnd == list[ i ].hwndBtn ) {
                //delete button
                list[ i ].txt.Dispose();
                list[ i ].btn.Dispose();
                list.RemoveAt( i );
                return;
            }
        }
    }
    private int FindPosition() {
        int i, j;
        //check the first position that is empty 0 - (maxCntrs -1) lines
        for( i = 0; i < maxCntrs; i++ ) {
            //run all list
            for( j = 0; j < list.Count; j++ ) {
                if( i == list[ j ].position ) {
                    break;
                }
            }
            if(j == list.Count ) { //position is found
                return i;
            }
        }
            
        return -1; //not found
    }
    private void timer1_Tick( object sender, EventArgs e ) {
        int i;
        //for all elements in list decrease timerLife. If timerLife is 0 then remove
        for( i = 0; i < list.Count; i++ ) {
            Node node;
            node = list[ i ];
            node.timerLife--;
            list[ i ] = node;
            if( list[ i ].timerLife == 0  ) {
                Remove( list[ i ].hwndBtn );
             }
            else {
                list[ i ].txt.Text = list[ i ].timerLife.ToString();
            }
        }
    }
