           private void btnDeal_Click(object sender, EventArgs e)
        {   
            
            delear.Deal(player, 2);
            //gets the file paths of the pictures used to load images into picture boxes
            foreach (KeyValuePair<string, int> entry in player.GetCardRankSuit())
            {
                CreateControlsPlayer(entry.Key, entry.Value, pnlPlayer);
            }
           
          }
