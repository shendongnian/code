    foreach(Slide slide in slidePack.slides)
    {
         if(slide.type == SlideType.SECTION_MARKER)
         {
             Section sec = (Section)slide;
             //use sec.SectionProperty
         }
    }
