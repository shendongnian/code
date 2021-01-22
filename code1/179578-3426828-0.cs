        private MemberInfo getSource(Type destinationType, string destinationPropertyname)
        {
            TypeMap map = Mapper.GetAllTypeMaps().Where(m => m.DestinationType.Equals(destinationType)).First();
            IEnumerable<PropertyMap> properties = map.GetPropertyMaps().Where(p => p.DestinationProperty.Name.Equals(destinationPropertyname, StringComparison.CurrentCultureIgnoreCase));
            PropertyMap sourceProperty = properties.First();
            IMemberGetter mg = sourceProperty.GetSourceValueResolvers().Cast<IMemberGetter>().First();
            return mg.MemberInfo;
        }
