     public void Setup(IList<CapturedResultModel> capturedResults)
            {
              
                Pages = new UIImageView[capturedResults.Count];
                var pageSize = Frame.Size;
                ContentSize = new CGSize(pageSize.Width * Pages.Length, pageSize.Height);
    
                backView = new UIView()
                {
                   //set the backView's size same as scrollview's contentSize
                    Frame = new CGRect(15,40,pageSize.Width * capturedResults.Count, pageSize.Height),                
                    BackgroundColor = UIColor.Blue,
                    ClipsToBounds = true
                };
    
                Add(backView);
    
                for (int page = 0; page < capturedResults.Count; page++)
                {       
    
                    var imageView = new UIImageView()
                    {
                        
                        Frame = new CGRect( pageSize.Width * page, 0,pageSize.Width - 30, pageSize.Height),                    
                        Image = UIImage.FromBundle(capturedResults[page].ResultImagePath),
                        BackgroundColor = UIColor.Blue,
                        ClipsToBounds = true
                    };
    
                    backView.AddSubview(imageView);
                    Pages[page] = imageView;
    
                }
            }
 
