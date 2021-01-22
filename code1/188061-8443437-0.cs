        public object GetPropertyValue(object target, ResourceProperty resourceProperty)
        {
            object result = null;
            PropertyInfo info = target.GetType().GetProperty(resourceProperty.Name);
            if (info != null)
                result = info.GetValue(target, null);
            if (result is Enum)
                return Convert.ToInt32(result);
            return result;
        }
        public ResourceType GetResourceType(object target)
        {
            ResourceType result = null;
            Type tp = target.GetType();
            if (tp.IsEnum)
            {
                result =  ResourceType.GetPrimitiveResourceType(typeof(Int32));
                return result;
            }
            ....
            return result;
        }
