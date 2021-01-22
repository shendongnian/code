        public static void DuckCopyShallow(this Object dst, object src)
        {
            var srcT = src.GetType();
            var dstT= dst.GetType();
            foreach(var f in srcT.GetFields())
            {
                var dstF = dstT.GetField(f.Name);
                if (dstF == null)
                    continue;
                dstF.SetValue(dst, f.GetValue(src));
            }
            foreach (var f in srcT.GetProperties())
            {
                var dstF = dstT.GetProperty(f.Name);
                if (dstF == null)
                    continue;
                
                dstF.SetValue(dst, f.GetValue(src, null), null);
            }
        }
