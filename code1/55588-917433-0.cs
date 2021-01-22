           Infragistics.Win.UltraWinTree.Override ovr;
           // Get the tree's Override property so we can
           // set the default for all nodes.
           ovr = this.ultraTree1.Override;
           // Turn hot tracking on
           ovr.HotTracking = DefaultableBoolean.True;
           // Set the borderstyle to solid but the border color
           // to trasnparent so the borders don't show by default.
           ovr.BorderStyleNode = UIElementBorderStyle.Solid;
           ovr.NodeAppearance.BorderColor = Color.Transparent;
           // Set default border colors for active, expanded,
           // hot tracked and selected nodes.
           ovr.ActiveNodeAppearance.BorderColor = Color.Red;
           ovr.ExpandedNodeAppearance.BorderColor = Color.Magenta;
           ovr.HotTrackingNodeAppearance.BorderColor = Color.Blue;
           ovr.SelectedNodeAppearance.BorderColor = Color.Black;
