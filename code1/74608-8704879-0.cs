    using System.Windows.Controls.Primitives;
    
    private void LB_Loaded()
    {
      var itemsPanel = LB.GetVisualChildren().OfType<Panel>().FirstOrDefault();
    }
