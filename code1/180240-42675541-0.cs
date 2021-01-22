    static class Utilities {
        public static List<T> GetAllControls<T>(this Control container) where T : Control {
            List<T> controls = new List<T>();
            if (container.Controls.Count > 0) {
                controls.AddRange(container.Controls.OfType<T>());
                foreach (Control c in container.Controls) {
                    controls.AddRange(c.GetAllControls<T>());
                }
            }
    
            return controls;
        }
    }
