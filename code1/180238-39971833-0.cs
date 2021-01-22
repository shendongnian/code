        public static IEnumerable<T> GetAllControls<T>(this Control control) where T : Control
        {
            foreach (Control c in control.Controls)
            {
                if (c is T)
                    yield return (T)c;
                foreach (T c1 in c.GetAllControls<T>())
                    yield return c1;
            }
        }
