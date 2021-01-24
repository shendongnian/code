    private void PrintPage(object sender, PrintPageEventArgs e)
    {
      try
      {
        if (File.Exists(toPrint) && nbrPrint < nbrPages)
        {
          Rectangle m = panel1.ClientRectangle;
          Bitmap imaag = new Bitmap(m.Width, m.Height);
          panel1.DrawToBitmap(imaag, m);
          e.Graphics.DrawImage(imaag, e.MarginBounds);
          nbrPrint++;
          compteurPrint++;
          cpt.Text = compteurPrint.ToString();
          e.HasMorePages = true; // Set this to true as long as there are more pages to print. It defaults to false.
        }
      }
      catch (Exception)
      {
      }
    }
