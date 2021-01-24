    public override void ViewWillAppear(bool animated)
            {
                base.ViewWillAppear(animated);
    
                IList<CapturedResultModel> CapturedResults = new List< CapturedResultModel >{ new CapturedResultModel { ResultImagePath = "Images1" },
                                                                                              new CapturedResultModel { ResultImagePath = "Images2"},
                                                                                              new CapturedResultModel { ResultImagePath = "Images1" }
                                                                                              };
    
                CaptureResultScrollView CapturedResultScrollView = new CaptureResultScrollView();
                CapturedResultScrollView.Frame = new CGRect(15, 40, View.Frame.Size.Width - 30, View.Frame.Size.Height-80);
                CapturedResultScrollView.Setup(CapturedResults);
                Add(CapturedResultScrollView);
            }
