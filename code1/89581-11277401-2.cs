     class DragDrop : DropTarget
        {
            
            public override void OnDrop(System.Windows.Forms.DragEventArgs e)
            {
                using (DocumentLock docLock = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.LockDocument())
                {
            //        MyCommands mc = new MyCommands();
              //      mc.CircleJig();
            
                    //Call your own methods etc here.
            
                 }
    
            }
