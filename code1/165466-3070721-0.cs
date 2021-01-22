    string inputText = "...";
    string[] subRegions = inputText.Split( "*" );
    // split final region into bullet and sentance based on first period...
    string[] lastRegions = subRegions[subRegion.Length-1].Split(new[]{'.'},2);
    // replace the final subregion with the combined parts (bullet/sentence)
    subRegions[subRegions.Length-1] = string.Join(". <br/>",lastRegions);
    // combine all subregions together, replacing `*` with bulletized breaks.
    string finalText = string.Join( "<br/>*", subRegions );
    
                  
                                               
