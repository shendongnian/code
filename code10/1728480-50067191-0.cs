      // Selects what style applies to a list view item according to that item's properties when it is rendered
      public class ColumnStyleSelector : StyleSelector
      {
         protected override Style SelectStyleCore(object item, DependencyObject container)
         {
            Tile tile = (Tile)item;
            if(tile.Type == (int)TileType.ExplodedMine)
            {
               return mainPage.Resources["TileExploded"] as Style;
            }
            else if(tile.IsRevealed == true && tile.IsShownGraphically == true)
            {
               switch(tile.AdjacentMines)
               {
                  case 0:
                     return mainPage.Resources["Tile0"] as Style;
                  case 1:
                     return mainPage.Resources["Tile1"] as Style;
                  case 2:
                     return mainPage.Resources["Tile2"] as Style;
                  case 3:
                     return mainPage.Resources["Tile3"] as Style;
                  case 4:
                     return mainPage.Resources["Tile4"] as Style;
                  default:
                     return mainPage.Resources["ListViewItem"] as Style;
               }
            }
            else
            {
               return mainPage.Resources["ListViewItem"] as Style;
            }
         }
      }
