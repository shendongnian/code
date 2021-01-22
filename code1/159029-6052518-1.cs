    public class MyTreeView : TreeView {
        protected override void OnKeyDown(KeyEventArgs e) {
            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0 && e.Key == Key.Tab)
                return;
            base.OnKeyDown(e);
        }
    }
