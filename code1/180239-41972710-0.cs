        public IEnumerable<T> GetAll<T>(Control control) where T : Control
        {
            var type = typeof(T);
            var controls = control.Controls.Cast<Control>().ToArray();
            foreach (var c in controls.SelectMany(GetAll<T>).Concat(controls))
                if (c.GetType() == type) yield return (T)c;
        }
