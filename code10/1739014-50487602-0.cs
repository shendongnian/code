     private UIImage GetTabIcon(string title)
      {
        UITabBarItem item = null;
        switch (title)
        {
          case "Dairy":
          item = new UITabBarItem("Dairy", UIImage.FromFile("dairy"), 0);
          break;
          case "My kid":
          item = new UITabBarItem("My kid",UIImage.FromFile("kid"),0);
          break;
         }
          var img = (item != null) ? UIImage.FromImage(item.SelectedImage.CGImage, item.SelectedImage.CurrentScale, item.SelectedImage.Orientation) : new UIImage();
          return img;
      }
