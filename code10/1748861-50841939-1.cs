    returnedObjectIDs = new List<int>(db.WordObjectMaps
        .Where(c =>
            c.ForObjectTypeID == TopicObjectTypeID
            && AllWordIDsAndWeightings.ContainsKey(c.WordID)
        )
        .Select(c => new { Word = c, Weight = AllWordIDsAndWeightings[c.WordID])
        .GroupBy(c => x.Word.Value * c.Weight) // replace with your condition
        .Select(c => c.Key)
    );
