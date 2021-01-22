        /// <summary>
        /// Recurses through all controls, starting at given control,
        /// and returns an array of those matching the given criteria.
        /// 
        public Control[] FilterControls(Control start, Func<Control, bool> isMatch) {
            var matches = new List<Control>();
            Action<Control> filter = null;
            (filter = new Action<Control>(c => {
                if (isMatch(c))
                    matches.Add(c);
                foreach (Control c2 in c.Controls)
                    filter(c2);
            }))(start);
            return matches.ToArray();
        }
