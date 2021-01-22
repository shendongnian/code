    private void SerializeValue(object o, StringBuilder sb, int depth, Hashtable objectsInUse)
    {
        if (++depth > this._recursionLimit)
        {
            throw new ArgumentException(AtlasWeb.JSON_DepthLimitExceeded);
        }
        JavaScriptConverter converter = null;
        if ((o != null) && this.ConverterExistsForType(o.GetType(), out converter))
        {
            IDictionary<string, object> dictionary = converter.Serialize(o, this);
            if (this.TypeResolver != null)
            {
                string str = this.TypeResolver.ResolveTypeId(o.GetType());
                if (str != null)
                {
                    dictionary["__type"] = str;
                }
            }
            sb.Append(this.Serialize(dictionary));
        }
        else
        {
            this.SerializeValueInternal(o, sb, depth, objectsInUse);
        }
    }
