        public static T ToEnum<T>(this object value)
        {
            //Checking value is null or DBNull
            if (!value.IsNull())
            {
                return (T)Enum.Parse(typeof(T), value.ToStringX());
            }
            //Returanable object
            object ValueToReturn = null;
            //First checking whether any 'DefaultValueAttribute' is present or not
            var DefaultAtt = (from a in typeof(T).CustomAttributes
                              where a.AttributeType == typeof(DefaultValueAttribute)
                              select a).FirstOrNull();
            //If DefaultAttributeValue is present
            if ((!DefaultAtt.IsNull()) && (DefaultAtt.ConstructorArguments.Count == 1))
            {
                ValueToReturn = DefaultAtt.ConstructorArguments[0].Value;
            }
            //If still no value found
            if (ValueToReturn.IsNull())
            {
                //Trying to get the very first property of that enum
                Array Values = Enum.GetValues(typeof(T));
                //getting very first member of this enum
                if (Values.Length > 0)
                {
                    ValueToReturn = Values.GetValue(0);
                }
            }
            //If any result found
            if (!ValueToReturn.IsNull())
            {
                return (T)Enum.Parse(typeof(T), ValueToReturn.ToStringX());
            }
            return default(T);
        }
