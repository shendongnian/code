        IEnumerable RecurseObjects(object root) {
            Queue items = new Queue();
            items.Enqueue(root);
            while (items.Count > 0) {
                object obj = items.Dequeue();
                yield return obj;
                Control control = obj as Control;
                if (control != null) {
                    // regular controls and sub-controls
                    foreach (Control item in control.Controls) {
                        items.Enqueue(item);
                    }
                    // top-level menu items
                    ToolStrip ts = control as ToolStrip;
                    if (ts != null) {
                        foreach(ToolStripItem tsi in ts.Items) {
                            items.Enqueue(tsi);
                        }
                    }
                }
                // child menus
                ToolStripDropDownItem tsddi = obj as ToolStripDropDownItem;
                if (tsddi != null && tsddi.HasDropDownItems) {
                    foreach (ToolStripItem item in tsddi.DropDownItems) {
                        items.Enqueue(item);
                    }
                }
            }            
        }
