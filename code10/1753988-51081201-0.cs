    public void Set( int score )
    {
        int who = score / 1000;
        
        if (who == 1)
        {
            NGUITools.SetActive(obj_player, true );
            NGUITools.SetActive(obj_banker, false);
        }
        else if( who == 2)
        {
            NGUITools.SetActive(obj_player, false);
            NGUITools.SetActive(obj_banker, true);
        }
        else
        {
            NGUITools.SetActive(obj_player, false);
            NGUITools.SetActive(obj_banker, false);
            NGUITools.SetActive(lbl_tie_no.gameObject, false);
            NGUITools.SetActive(spr_playerPair.gameObject, false);
            NGUITools.SetActive(spr_bankerPair.gameObject, false);
            return;
        }
    }
