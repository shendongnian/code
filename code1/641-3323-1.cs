    // Generic function that gets all child controls of a certain type, 
    // returned in a List collection
    private static List<T> GetChildTextBoxes<T>(Control ctrl) where T : Control{
        List<T> tbs = new List<T>();
        foreach (Control c in ctrl.Controls) {
            // If c is of type T, add it to the collection
            if (c is T) { 
                tbs.Add((T)c);
            }
        }
        return tbs;
    }
    private static void SetChildTextBoxesHeight(Control ctrl, int height) {
        foreach (TextBox t in GetChildTextBoxes<TextBox>(ctrl)) {
            t.Height = height;
        }
    }
