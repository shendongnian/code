     private void MakePanelVisisble(Panel panel) {
       Panel[] panels = new Panel[] {
         pnlItems, pnlCustomer, pnlPOS, pnlDelivery,
       }; 
       foreach (var p in panels)
         p.Visible = (p == panel);
     }
