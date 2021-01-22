    public class EntityJsonConverter : System.Web.Script.Serialization.JavaScriptConverter
    {
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            Entity entity = obj as Entity;
            if (entity != null)
            {
                var values = new Dictionary<string, object>();
                TypeConverter idTypeConverter = TypeDescriptor.GetConverter(entity.Id);
                if (idTypeConverter != null)
                {
                    if (idTypeConverter.CanConvertTo(typeof(string)))
                        values.Add("Id", idTypeConverter.ConvertTo(entity.Id, typeof(string)));
                    else
                        throw new SerializationException(string.Format("The TypeConverter for type \"{0}\" cannot convert to string.", this.GetType().FullName));
                }
                else
                    throw new SerializationException(string.Format("Unable to find a TypeConverter for type \"{0}\".", this.GetType().FullName));
                values.Add("Data", serializer.Serialize(entity.Data));
                return values;
            }
            else
                throw new ArgumentException(string.Format("Expected argument of type \"{0}\", but received \"{1}\".", typeof(Entity).FullName, obj.GetType().FullName), "obj");
        }
        public override IEnumerable<Type> SupportedTypes
        {
            get { yield return typeof(Entity); }
        }
    }
