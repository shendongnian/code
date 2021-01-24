    public static void CloneSlideLayout(this SlidePart newSlidePart, SlideLayoutPart slPart, string id)
    {
        // creates a Slide from a SlideLayout
        /* ensure we added the rel ID to this part */
        newSlidePart.AddPart(slPart, id);
        using (Stream stream = slPart.GetStream()) { newSlidePart.SlideLayoutPart.FeedData(stream); }
        newSlidePart.Slide.CommonSlideData = (CommonSlideData)slPart.SlideLayout.CommonSlideData.Clone();
        foreach (ImagePart iPart in slPart.ImageParts)
        {
            newSlidePart.AddPart<ImagePart>(iPart, slPart.GetIdOfPart(iPart));
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
            SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.FirstOrDefault();
            SlideLayoutPart slideLayoutPart = slideMasterPart.GetSlideLayoutPartByLayoutName(layoutName);
            Slide slide = new Slide(  );
            SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
            slide.Save(slidePart);
            string id = slideMasterPart.GetIdOfPart(slideLayoutPart);
            slidePart.CloneSlideLayout(slideLayoutPart, id);
            presentationPart.AppendSlide(slidePart); 
    }
