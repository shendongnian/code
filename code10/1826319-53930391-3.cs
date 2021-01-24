        // pick the top parent; in my case it wa a TabPage (not shown)
        Control ctrl = pickTheParent;  
        foreach (Control c in ctrl.Controls) StoreBounds(ctrl, c);
        }
        ctrl.Resize += (ss, ee) =>
        {
            foreach (Control c in ctrl.Controls)  ScaleBounds(c);
        };
    }
