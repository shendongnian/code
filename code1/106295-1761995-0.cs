		{
			PrintDocument doc = new PrintDocument ();
			doc.PrintPage += new PrintPageEventHandler ( doc_PrintPage );
			doc.Print ();
		}
		void doc_PrintPage ( object sender, PrintPageEventArgs e )
		{
			Graphics g = e.Graphics;
			g.DrawImage ( youImage, 0, 0 );
		}
