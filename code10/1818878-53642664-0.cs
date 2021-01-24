    private void picApple_Click(object sender, EventArgs e)
    {
      picApple.Image = Properties.Resources.apple;
      if (uncoveredCard1 == null)
      {
        uncoveredCard1 = picApple;
      }
      else if (uncoveredCard1 != null && uncoveredCard2 == null)
      {
        uncoveredCard2 = picApple;
      }
      else if (uncoveredCard1 != null && uncoveredCard2 != null)
      {
        if (uncoveredCard1.Tag == uncoveredCard2.Tag)
        {
          uncoveredCard1 = null;
          uncoveredCard2 = null;
          picApple.Visible = false;
          wrdApple.Visible = false;
        }
        else
        {
          showCard.Start();
        }
    }
