      // remove unneeded EXIF data
      using (ImageFactory ifact = new ImageFactory()) {
        ifact.PreserveExifData = true;
        ifact.Load(ImageFilename);
        // IDs to keep: model, orientation, DateTime, DateTimeOriginal
        List<int> PropIDs = new List<int>(new int[] { 272, 274, 306, 36867 });
        // get the property items from the image
        ConcurrentDictionary<int, PropertyItem> EXIF_Dict = ifact.ExifPropertyItems;
        List<int> foundList = new List<int>();
        foreach (KeyValuePair<int, PropertyItem> kvp in EXIF_Dict) foundList.Add(kvp.Key);
        // remove EXIF tags unless they are in the PropIDs list
        foreach (int id in foundList) {
          PropertyItem junk;
          if (!PropIDs.Contains(id)) {
            // the following line removes a tag
            EXIF_Dict.TryRemove(id, out junk);
          }
        }
        // change the retained tag's values here if desired
        EXIF_Dict[274].Value[0] = 1;
        // save the property items back to the image
        ifact.ExifPropertyItems = EXIF_Dict;
      }
