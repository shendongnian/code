     private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
         {
         string currentDockPane = e.Item.Content.ToString();       
          switch (currentDockPane)
              {
                case "view":
               var currentLayout= StandardDockManager.Layout.Descendents().OfType<LayoutAnchorable>().Where(x => x.ContentId == "view").FirstOrDefault();
         //Get all the descendents of current dock manger and check for the LayoutAnchorable if its visible .
                    if (currentLayout.IsVisible)
                   (((Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable)(currentLayout))).IsVisible = false;
                                 else
                   (((Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable)(currentLayout))).IsVisible = true;
                break;
                  .......................
            }
        }
