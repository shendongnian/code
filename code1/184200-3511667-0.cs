        internal void ResolveResources(Assembly _assembly)
        {
            if (_assembly != null && this._icon_name != null)
            {                   
                var stream = _assembly.GetManifestResourceStream(string.Format("{0}.Resources.{1}",_assembly.GetName().Name,this._icon_name));
                if (stream != null) this._icon = new Bitmap(stream);
            }
        }
