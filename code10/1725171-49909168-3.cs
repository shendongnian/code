    if (nd.Attributes.Count > 0)
    {
        XmlAttributeCollection coll = nd.Attributes;
        foreach (XmlAttribute cn in coll)
        {
            switch (cn.Name)
            {
                case "Name":
                    thisStar.Name = cn.Value;
                    break;
                case "SpectralType":
                    thisStar.SpectralClass = cn.Value;
                    break;
            }
        }
    }
