        private void Foo(bool enabled)
        {
            foreach (Control c in this.Controls)
                if (c is Button && c.Tag != null)
                    c.Enabled = enabled;
        }
