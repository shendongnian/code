    public new TreeNode SelectedNode {
        get { return base.SelectedNode; }
        set {
            // Remember, if `value' is not null this will be called in `base'.
            if (value == null) {
                TreeViewCancelEventArgs args
                    = new TreeViewCancelEventArgs(value, false, TreeViewAction.Unknown);
                OnBeforeSelect(args);
                if (args.Cancel)
                    return;
            }
            base.SelectedNode = value;
            // Remember, if `value' is not null this will be called in `base'.
            if (value == null) {
                OnAfterSelect(new TreeViewEventArgs(value, TreeViewAction.Unknown));
            }
        }
    }
