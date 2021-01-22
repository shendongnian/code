        internal override bool IsValidProperty(Principal p, string propertyName)
        {
            ObjectMask none = ObjectMask.None;
            if (!ValidPropertyMap.TryGetValue(propertyName, out none))
            {
                return false;
            }
            if ((MaskMap[p.GetType()] & none) <= ObjectMask.None)
            {
                return false;
            }
            return true;
        }
