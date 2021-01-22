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
                //edit for itemremove
                case 0x1008:
                    System.Diagnostics.Debug.WriteLine("Item removed");
                    break;
                case 0x1009:
                    System.Diagnostics.Debug.WriteLine("Item removed (All)");
                    break;
                default:
                    break;
            }
        }
    }
