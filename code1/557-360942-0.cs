         // only need to change selected note during right-click - otherwise tree does
         // fine by itself
         if ( e.Button == MouseButtons.Right )
         {         
            Point pt = new Point( e.X, e.Y );
            tree.PointToClient( pt );
            TreeNode Node = tree.GetNodeAt( pt );
            if ( Node != null )
            {
               if ( Node.Bounds.Contains( pt ) )
               {
                  tree.SelectedNode = Node;
                  ResetContextMenu();
                  contextMenuTree.Show( tree, pt );
               }
            }
         }
      }
