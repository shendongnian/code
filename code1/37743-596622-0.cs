    public class ExampleConverter : JavaScriptConverter
    {
        /// <summary>
        /// Gets a collection of the supported types
        /// </summary>
        /// <value>An object that implements <see cref="IEnumerable{T}"/> that represents the types supported by the converter. </value>
        public override IEnumerable<Type> SupportedTypes
        {
            get
            {
                return new ReadOnlyCollection<Type>(new Type[] { typeof(MyExampleType) });
            }
        }
        /// <summary>
        /// Converts the provided dictionary into an object of the specified type. 
        /// </summary>
        /// <param name="dictionary">An <see cref="IDictionary{TKey,TValue}"/> instance of property data stored as name/value pairs. </param>
        /// <param name="type">The type of the resulting object.</param>
        /// <param name="serializer">The <see cref="JavaScriptSerializer"/> instance. </param>
        /// <returns>The deserialized object. </returns>
        /// <exception cref="InvalidOperationException">We only serialize</exception>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            throw new InvalidOperationException("We only serialize");
        }
        /// <summary>
        /// Builds a dictionary of name/value pairs
        /// </summary>
        /// <param name="obj">The object to serialize. </param>
        /// <param name="serializer">The object that is responsible for the serialization. </param>
        /// <returns>An object that contains key/value pairs that represent the object’s data. </returns>
        /// <exception cref="InvalidOperationException"><paramref name="obj"/> must be of the <see cref="MyExampleType"/> type</exception>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            MyExampleType example = obj as MyExampleType;
            if (example == null)
            {
                throw new InvalidOperationException("object must be of the MyExampleType type");
            }
            IDictionary<string, object> jsonExample = new Dictionary<string, object>();
            jsonExample.Add("arrayMember", example.People.ToArray());
            jsonExample.Add("otherMember", example.Member);
            return jsonExample;
        }
    }
