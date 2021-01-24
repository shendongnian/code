      PdfPTable FinalTableN = new PdfPTable( 7 );
      PdfPRow[] n = PDFtableN.Rows.ToArray();
      int half = n.Length/2;
      PdfPRow[] s1 = new PdfPRow[half];
      PdfPRow[] s2 = new PdfPRow[half];
      for (int h = 0; h < half; h++ )
        s1[h] = n[h];
      for ( int h = half; h < n.Length; h++ )
        s2[h-half] = n[h];
      for ( int h = 0; h < half; h++ ) {
        FinalTableN.AddCell( s1[h].GetCells()[0] );
        FinalTableN.AddCell( s1[h].GetCells()[1] );
        FinalTableN.AddCell( s1[h].GetCells()[2] );
        FinalTableN.AddCell( "" );
        FinalTableN.AddCell( s2[h].GetCells()[0] );
        FinalTableN.AddCell( s2[h].GetCells()[1] );
        FinalTableN.AddCell( s2[h].GetCells()[2] );
      }
