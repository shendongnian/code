     private void MakePanelVisisble(Panel panel) {
       Panel[] panels = new Panel[] {
         pnlItems, pnlCustomer, pnlPOS.Visible, pnlDelivery.Visible,
       }; 
       foreach (var p in panels)
         p.Visible = (p == panel);
     }
