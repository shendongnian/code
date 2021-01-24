    private void loadCrowdObjectsOnScreen(UniformGrid ug, EventHandler handler) {
        foreach (PlayerCrowdObjectBO childObject in childCrowdObjectOC) {
           Button b = new Button();
           b.Tag = childObject.ObjectNbr;
           b.Height = 25;
           b.Margin = new Thickness(5);
           b.Content = childObject.ObjectName + "  #" + childObject.ObjectNbr;
           b.Click += handler;
           ug.Children.Add(b);
        }
     }
