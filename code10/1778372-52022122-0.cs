    using (var reader = ...){
        while(!reader.EndOfStream){
            var line = reader.ReadLine();
            if(!string.IsNullOrWhitespace(line))
                //add line 
        }
    }
