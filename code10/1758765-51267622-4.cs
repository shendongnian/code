    private void _insertNewSlide(PresentationPart presentationPart, string layoutName)
    {
        Slide slide = new Slide();
        SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
            
        slide.Save(slidePart);
        SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.FirstOrDefault();
        SlideLayoutPart slideLayoutPart = slideMasterPart.GetSlideLayoutPartByLayoutName(layoutName); // extension method
        /* ensure we added the rel ID to this part */
        slidePart.AddPart<SlideLayoutPart>(slideLayoutPart, slideMasterPart.GetIdOfPart(slideLayoutPart));
            
        slidePart.Slide.CommonSlideData = (CommonSlideData)slideLayoutPart.SlideLayout.CommonSlideData.Clone();
        slidePart.CloneSlideLayout(slideLayoutPart); // extension method
        presentationPart.AppendSlide(slidePart); // extension method
    }
