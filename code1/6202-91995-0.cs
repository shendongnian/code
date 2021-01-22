    class TreeNodeController {
      Entity data; 
    
      virtual bool IsReadOnly { get; }
      virtual bool CanDrop(TreeNodeController source, DragDropEffects effect);
      virtual bool CanDrop(DataInfoObject info, DragDropEffects effect);
      virtual bool CanRename();
    }
    
    class ParentNodeController : TreeNodeController {
      override bool IsReadOnly { get { return data.IsReadOnly; } } 
      override bool CanDrop(TreeNodeController source, DragDropEffect effect) {
        return !IsReadOnly && !data.IsChildOf(source.data) && effect == DragDropEffect.Move;
      }
      virtual bool CanDrop(DataInfoObject info, DragDropEffects effect) {
        return info.DragDataCollection != null;
      }
      override bool CanRename() { 
        return !data.IsReadOnly && data.HasName;
      }
    }
    
    class LeafNodeController : TreeNodeController {
      override bool CanDrop(TreeNodeController source, DragDropEffect effect) {
        return false;
      }
    }
