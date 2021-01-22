    class myListView : ListView {
        
        protected override void WndProc(ref Message m){
            base.WndProc(ref m);
            
            switch (m.Msg){
                case 0x1007:    //ListViewItemAdd-A
                    System.Diagnostics.Debug.WriteLine("Item added (A)");
                    break;
                case 0x104D:    //ListViewItemAdd-W
                    System.Diagnostics.Debug.WriteLine("Item added (W)");
                    break;
                default:
                    break;
            }
        }
    }
