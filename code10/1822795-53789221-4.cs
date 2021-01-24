        StringBuilder repeatIndexes = new StringBuilder();
        int numberHalf = 3;
        // int repeatTime = 0;
        while (numberHalf > 0)
        {
            // replace below line with your char in array
            char insertThis = 'X'; //indexJustForRepetas[IndexOfIndexes[repeatTime]];   
            repeatIndexes.Append($"~{insertThis}");
            // repeatTime += 1 // needed for array call above. +1 or +2 depending on your intention
            numberHalf = numberHalf - 1;
        }
        var outString = repeatIndexes.ToString();
        output:
        ~X~X~X
