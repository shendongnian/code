    public static void Copy(Stream sourcePresentationStream, uint copiedSlidePosition, Stream destPresentationStream)
    {            
        using (var destDoc = PresentationDocument.Open(destPresentationStream, true))
        {
            var sourceDoc = PresentationDocument.Open(sourcePresentationStream, false);
            var destPresentationPart = destDoc.PresentationPart;
            var destPresentation = destPresentationPart.Presentation;
    
            _uniqueId = GetMaxIdFromChild(destPresentation.SlideMasterIdList);
            uint maxId = GetMaxIdFromChild(destPresentation.SlideIdList);
    
            var sourcePresentationPart = sourceDoc.PresentationPart;
            var sourcePresentation = sourcePresentationPart.Presentation;
    
            int copiedSlideIndex = (int)--copiedSlidePosition;
            
            int countSlidesInSourcePresentation = sourcePresentation.SlideIdList.Count();                
            if (copiedSlideIndex < 0 || copiedSlideIndex >= countSlidesInSourcePresentation)
                throw new ArgumentOutOfRangeException(nameof(copiedSlidePosition));
           
            SlideId copiedSlideId = sourcePresentationPart.Presentation.SlideIdList.ChildElements[copiedSlideIndex] as SlideId;
            SlidePart copiedSlidePart = sourcePresentationPart.GetPartById(copiedSlideId.RelationshipId) as SlidePart; 
    
            SlidePart addedSlidePart = destPresentationPart.AddPart<SlidePart>(copiedSlidePart);
    
            SlideMasterPart addedSlideMasterPart = destPresentationPart.AddPart(addedSlidePart.SlideLayoutPart.SlideMasterPart);    
                            
    
            // Create new slide ID
            maxId++;
            SlideId slideId = new SlideId
            {
                Id = maxId,
                RelationshipId = destDoc.PresentationPart.GetIdOfPart(addedSlidePart)
            };
            destPresentation.SlideIdList.Append(slideId);
    
            // Create new master slide ID
            _uniqueId++;
            SlideMasterId slideMaterId = new SlideMasterId
            {
                Id = _uniqueId,
                RelationshipId = destDoc.PresentationPart.GetIdOfPart(addedSlideMasterPart)
            };
            destDoc.PresentationPart.Presentation.SlideMasterIdList.Append(slideMaterId);
    
            // change slide layout ID
            FixSlideLayoutIds(destDoc.PresentationPart);
            
            destDoc.PresentationPart.Presentation.Save();
        }
        sourcePresentationStream.Close();
        destPresentationStream.Close();
    }
