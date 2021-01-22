    public class ContextMenuWithNoteCommands : ContextMenu
    {
      protected virtual DependencyObject GetContainerForItemOverride()
      {
        return new NoteCommandMenuItemViewer();
      }
    }
