    public static void CloneSlideLayout(this SlidePart newSlidePart, SlideLayoutPart slPart)
    {
        // copies a SlideLayoutPart and image rels into newSlidePart
        using (Stream stream = slPart.GetStream()) { newSlidePart.SlideLayoutPart.FeedData(stream); }
        foreach (ImagePart iPart in slPart.ImageParts)
        {
            ImagePart newImagePart = newSlidePart.AddImagePart(iPart.ContentType, slPart.GetIdOfPart(iPart));
            newImagePart.FeedData(iPart.GetStream());
        }
    }
    public static uint GetNextSlideId(this SlideIdList slideIdList)
    {
        uint nextId;
        uint maxId = GetMaxSlideId(slideIdList);
        if (maxId == 0)
        {
            // Slide Id must be >= 256
            nextId = 256;
        }
        else
        {
            nextId = maxId++;
        }
        return nextId;
    }
    public static uint GetMaxSlideId(this SlideIdList slideIdList)
    {
            
        // find the highest id
        uint maxSlideId = 0;
        if (slideIdList.ChildElements.Count() > 0)
            maxSlideId = slideIdList.ChildElements
                .Cast<SlideId>()
                .Max(x => x.Id.Value);
        return maxSlideId;
    }
    public static SlideLayoutPart GetSlideLayoutPartByLayoutName(this SlideMasterPart slideMasterPart, string layoutName)
    {
        return slideMasterPart.SlideLayoutParts.SingleOrDefault
                (sl => sl.SlideLayout.CommonSlideData.Name.Value.Equals(layoutName, StringComparison.OrdinalIgnoreCase));
    }
    public static void AppendSlide(this PresentationPart presentationPart, SlidePart newSlidePart)
    {
        SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;
        // find the highest id
        uint nextSlideId = slideIdList.GetNextSlideId();
        // Insert the new slide into the slide list after the previous slide.
        SlideId newSlideId = new SlideId();
        newSlideId.Id = nextSlideId;
        newSlideId.RelationshipId = presentationPart.GetIdOfPart(newSlidePart);
        slideIdList.Append(newSlideId);
        presentationPart.Presentation.Save();
    }
