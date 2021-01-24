          BoxHomeColor.Items.Clear(); if( Game?.CurrentTeamGuest != null ) {
          foreach( var color in ( (TeamElement)Game.CurrentTeamGuest ).Colors )
          {
              var item = new Rectangle
              {
                  Fill = new SolidColorBrush( FromHex( color ) ),
                  Height = 16,
                  Width = 100,
                  VerticalAlignment = VerticalAlignment.Stretch,
                  Tag = color
              };
              BoxHomeColor.Items.Add( item );
          }
          if( BoxHomeColor.Items.Count > 0 )
          {
              BoxHomeColor.SelectedIndex = 0;
          } }
