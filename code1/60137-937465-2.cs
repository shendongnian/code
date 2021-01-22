        // restore the geometry of the form
        string s = (string)AppCuKey.GetValue(_rvn_Geometry);
        if (!String.IsNullOrEmpty(s))
        {
            int[] p = Array.ConvertAll<string, int>(s.Split(','),
                             new Converter<string, int>((t) => { return Int32.Parse(t); }));
            if (p != null && p.Length == 5)
                this.Bounds = ConstrainToScreen(new System.Drawing.Rectangle(p[0], p[1], p[2], p[3]));
        }
