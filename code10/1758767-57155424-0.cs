        presentationPart.InsertNewSlide("CV Full page");
        presentationPart.InsertNewSlide("CV Half page");
        presentationPart.InsertNewSlide("Credential full page");
        presentationPart.InsertNewSlide("CV or Credential 5 to a page", 3);
        public static void InsertNewSlide(this PresentationPart presentationPart, string layoutName, int? position = null)
        {
            Slide slide = new Slide();
            SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
            slide.Save(slidePart);
            SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.FirstOrDefault();
            SlideLayoutPart slideLayoutPart = slideMasterPart.GetSlideLayoutPartByLayoutName(layoutName);
            slidePart.AddPart(slideLayoutPart, slideMasterPart.GetIdOfPart(slideLayoutPart));
            slidePart.Slide.CommonSlideData = (CommonSlideData)slideLayoutPart.SlideLayout.CommonSlideData.Clone();
            string id = slideMasterPart.GetIdOfPart(slideLayoutPart);
            slidePart.CloneSlideLayout(slideLayoutPart, id);
            slideMasterPart.AddPart(slideLayoutPart, id);
            presentationPart.SetSlideID(slidePart, position);
        }
        public static void SetSlideID(this PresentationPart presentationPart, SlidePart slidePart, int? position = null)
        {
            SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;
            if (slideIdList == null)
            {
                slideIdList = new SlideIdList();
                presentationPart.Presentation.SlideIdList = slideIdList;
            }
            if (position != null && position > slideIdList.Count())
                throw new InvalidOperationException($"Unable to set slide to position '{position}'. There are only '{slideIdList.Count()}' slides.");
            uint newId = slideIdList.ChildElements.Count() == 0 ? 256 : slideIdList.GetMaxSlideId() + 1;
            if (position == null)
            {
                var newSlideId = slideIdList.AppendChild(new SlideId());
                newSlideId.Id = newId;
                newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);
            }
            else
            {
                SlideId nextSlideId = (SlideId)slideIdList.ChildElements[position.Value - 1];
                var newSlideId = slideIdList.InsertBefore(new SlideId(), nextSlideId);
                newSlideId.Id = newId;
                newSlideId.RelationshipId = presentationPart.GetIdOfPart(slidePart);
            }
        }
        public static uint GetMaxSlideId(this SlideIdList slideIdList)
        {
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
        public static void CloneSlideLayout(this SlidePart newSlidePart, SlideLayoutPart slPart, string id)
        {
            /* ensure we added the rel ID to this part */
            newSlidePart.AddPart(slPart, id);
            using (Stream stream = slPart.GetStream()) { newSlidePart.SlideLayoutPart.FeedData(stream); }
            newSlidePart.Slide.CommonSlideData = (CommonSlideData)slPart.SlideLayout.CommonSlideData.Clone();
            foreach (ImagePart iPart in slPart.ImageParts)
                newSlidePart.AddPart(iPart, slPart.GetIdOfPart(iPart));
        }
