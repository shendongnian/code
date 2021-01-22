    public class DateTimeConverter : JavaScriptConverter {
        public override IEnumerable<Type> SupportedTypes {
            get { return new Type[] { typeof (TextAndDate) }; }
        }
    
        public override IDictionary<string, object> Serialize (
            object obj, JavaScriptSerializer serializer
        ) { throw new NotImplementedException (); }
    
        public override object Deserialize (
            IDictionary<string, object> dictionary, Type type,
            JavaScriptSerializer serializer
        ) {
            if (type == typeof (TextAndDate)) {
                TextAndDate td = new TextAndDate ();
                if (dictionary.ContainsKey ("text"))
                    td.Text = serializer.ConvertToType<string> (
                                                dictionary["text"]);
                //if (dictionary.ContainsKey ("date"))
                    td.Date = DateTime.Now;
                return td;
            }
            else
                return null;
        }
    }
