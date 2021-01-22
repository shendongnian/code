    public static List<ContentControl> GetAllContentControls(Document wordDocument)
        {
          if (null == wordDocument)
            throw new ArgumentNullException("wordDocument");
    
          List<ContentControl> ccList = new List<ContentControl>();
    
          // The code below search content controls in all
          // word document stories see http://word.mvps.org/faqs/customization/ReplaceAnywhere.htm
          Range rangeStory;
          foreach (Range range in wordDocument.StoryRanges)
          {
            rangeStory = range;
            do
            {
              try
              {
                foreach (ContentControl cc in rangeStory .ContentControls)
          {
            ccList .Add(cc);
          }
              }
              catch (COMException) { }
              rangeStory = rangeStory.NextStoryRange;
    
            }
            while (rangeStory != null);
          }
          return ccList;
        }
