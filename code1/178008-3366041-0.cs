        Dictionary<string, Func<MyObject, object>> propertyNameAssociations;
        private void BuildPropertyNameAssociations()
        {
            propertyNameAssociations = new Dictionary<string, Func<MyObject, object>>();
            propertyNameAssociations.Add("PropOne", x => x.prop1);
            propertyNameAssociations.Add("PropTwo", x => x.prop2);
        }
        public object GetMemberByName(MyObject myobj, string name)
        {
            if (propertyNameAssociations.Contains(name))
                return propertyNameAssociations[name](myobj);
            else
                return null;
        }
