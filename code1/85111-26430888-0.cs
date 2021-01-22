     private void ComputePreview() {
            int oldStart = StartPage;
 
            if (document == null)
                pageInfo = new PreviewPageInfo[0];
            else {
                IntSecurity.SafePrinting.Demand();
  
                PrintController oldController = document.PrintController;
    // --> HERE they have hardcoded it! Why they do this!
                PreviewPrintController previewController = new PreviewPrintController();
                previewController.UseAntiAlias = UseAntiAlias;
                document.PrintController = new PrintControllerWithStatusDialog(previewController,
                                                                               SR.GetString(SR.PrintControllerWithStatusDialog_DialogTitlePreview));
 
                // Want to make sure we've reverted any security asserts before we call Print -- that calls into user code
                document.Print();
                pageInfo = previewController.GetPreviewPageInfo();
                Debug.Assert(pageInfo != null, "ReviewPrintController did not give us preview info");
  
    // --> and then swap the old one
                document.PrintController = oldController;
            }
  
            if (oldStart != StartPage) {
                OnStartPageChanged(EventArgs.Empty);
            }
        }
