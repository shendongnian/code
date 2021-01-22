            var cipher = new Dictionary<char, int>();
            cipher.Add('a', 324);
            cipher.Add('b', 553);
            cipher.Add('c', 915);
            var nThValue = cipher.Select((Val, Index) => new { Val, Index })
                .Single(viPair => viPair.Index == 1)   //Selecting dictionary item with it's index using index
                .Val                                   //Extracting KeyValuePair from dictionary item
                .Value;                                //Extracting Value from KeyValuePair
