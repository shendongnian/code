    string[] columns = (line + "\t\t\t\t").Split(new [] {'\t'}, 5);
    
    Output0Buffer.AddRow();
    Output0Buffer.Column0 = columns[0];
    Output0Buffer.Column1 = columns[1];
    Output0Buffer.Column2 = columns[2];
    Output0Buffer.Column3 = columns[3];
    // The trim is needed on this line because the split method
    // will stop processing after it has hit the number of elements
    // listed in the count value
    Output0Buffer.Column4 = columns[4].TrimEnd('\t'); 
