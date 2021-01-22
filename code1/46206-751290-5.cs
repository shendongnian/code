    ChapterView chapterView;
    
    Page_Load()
    {
      if( !IsPostback )
      {
        ChapterView chapterView = GetChapterView();
      }
      else
      {
        chapterView = (ChapterView) ViewState["chapterview"];
      }
    }
    
    NextChapter_Click()
    {
      chaperView.NextChapter();
    }
      
    Page_PreRender()
    {
      FillQualityList(chapterView);
      SetChapterTitle(chapterView);
      DetermineView(chapterView);}
      // make sure class is marked [Serializable]
      ViewState["chapterview"] = chapterView; 
    }
