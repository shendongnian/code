    var awTable = db.Artworks.Where( aw => (bool)aw.IsArtworkVisible );  //the first was unnecessary
    
    foreach ( SearchTag tagToMatch in tagList )
    {
        awTable = awTable.AndAlso(aw => 
            aw.ArtworkName.Contains(tagToMatch.SearchTagText) ||
            db.SearchTag_x_Artworks.Where(stxa => stxa.SearchTagID == tagToMatch && stxa.ArtworkID == aw.ArtworkID);
    }
