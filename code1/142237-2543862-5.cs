    using System.Collections.Generic;
    using System.Diagnostics;
    using Salient.Reflection;
    
    namespace KVDTO
    {
        /// <summary>
        /// This is our DTO
        /// </summary>
        public class ClientCompany
        {
            public string Address1 { get; private set; }
            public string Address2 { get; private set; }
            public string AlternativeTelephoneNumber { get; private set; }
            public string CountyOrState { get; private set; }
            public string EmailAddress { get; private set; }
            public string Forenames { get; private set; }
            public string PostCode { get; private set; }
            public string Surname { get; private set; }
            public string TelephoneNumber { get; private set; }
            public string Title { get; private set; }
            public string TownOrDistrict { get; private set; }
        }
    
    
        /// <summary>
        /// This is our DTO Map
        /// </summary>
        public sealed class ClientCompanyMapping : KeyValueDtoMap<ClientCompany>
        {
            static ClientCompanyMapping()
            {
                AddMapping("Title", "Greeting");
                AddMapping("Forenames", "First");
                AddMapping("Surname", "Last");
                AddMapping("EmailAddress", "eMail");
                AddMapping("TelephoneNumber", "Phone");
                AddMapping("AlternativeTelephoneNumber", "Phone2");
                AddMapping("Address1", "Address1");
                AddMapping("Address2", "Address2");
                AddMapping("TownOrDistrict", "City");
                AddMapping("CountyOrState", "State");
                AddMapping("PostCode", "Zip");
            }
        }
    
    
        internal class Program
        {
            private const string Address1 = "1243 Easy Street";
            private const string CountyOrState = "Az";
            private const string EmailAddress = "nunya@bidnis.com";
            private const string Forenames = "Sky";
            private const string PostCode = "85282";
            private const string Surname = "Sanders";
            private const string TelephoneNumber = "800-555-1212";
            private const string Title = "Mr.";
            private const string TownOrDistrict = "Tempe";
    
            private static void Main(string[] args)
            {
                // this represents our input data, some discrepancies
                // introduced to demonstrate functionality of the map
    
                // the keys differ from the dto property names
                // there are missing properties
                // there are unrecognized properties
                var input = new Dictionary<string, string>
                    {
                        {"Greeting", Title},
                        {"First", Forenames},
                        {"Last", Surname},
                        {"eMail", EmailAddress},
                        {"Phone", TelephoneNumber},
                        // missing from this input {"Phone2", ""},
                        {"Address1", Address1},
                        // missing from this input {"Address2", ""},
                        {"City", TownOrDistrict},
                        {"State", CountyOrState},
                        {"Zip", PostCode},
                        {"SomeOtherFieldWeDontCareAbout", "qwerty"}
                    };
    
    
                // rehydration is simple and FAST
    
                // instantiate a map. You could store instances in a dictionary
                // but it is not really necessary for performance as all of the
                // work is done in the static constructors, so no matter how many
                // times you 'new' a map, it is only ever built once.
    
                var map = new ClientCompanyMapping();
    
                // do the work. 
                ClientCompany myDto = map.Load(input);
    
    
    
    
    
                // test
                Debug.Assert(myDto.Address1 == Address1, "Address1");
                Debug.Assert(myDto.Address2 == null, "Address2");
                Debug.Assert(myDto.AlternativeTelephoneNumber == null, "AlternativeTelephoneNumber");
                Debug.Assert(myDto.CountyOrState == CountyOrState, "CountyOrState");
                Debug.Assert(myDto.EmailAddress == EmailAddress, "EmailAddress");
                Debug.Assert(myDto.Forenames == Forenames, "Forenames");
                Debug.Assert(myDto.PostCode == PostCode, "PostCode");
                Debug.Assert(myDto.Surname == Surname, "Surname");
                Debug.Assert(myDto.TelephoneNumber == TelephoneNumber, "TelephoneNumber");
                Debug.Assert(myDto.Title == Title, "Title");
                Debug.Assert(myDto.TownOrDistrict == TownOrDistrict, "TownOrDistrict");
            }
        }
    
        /// <summary>
        /// Base mapper class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class KeyValueDtoMap<T> where T : class, new()
        {
            private static readonly List<DynamicProperties.Property> Props;
            private static readonly Dictionary<string, string> KvMap;
    
            static KeyValueDtoMap()
            {
                // this property collection is built only once
                Props = new List<DynamicProperties.Property>(DynamicProperties.CreatePropertyMethods(typeof(T)));
                KvMap=new Dictionary<string, string>();
            }
    
            /// <summary>
            /// Adds a mapping between a DTO property and a KeyValue pair
            /// </summary>
            /// <param name="dtoPropertyName">The name of the DTO property</param>
            /// <param name="inputKey">The expected input key</param>
            protected static void AddMapping(string dtoPropertyName,string inputKey)
            {
                KvMap.Add(dtoPropertyName,inputKey);
            }
    
            /// <summary>
            /// Creates and loads a DTO from a Dictionary
            /// </summary>
            /// <param name="input"></param>
            /// <returns></returns>
            public T Load(Dictionary<string, string> input)
            {
                var result = new T();
                Props.ForEach(p =>
                    {
                        string inputKey = KvMap[p.Info.Name];
                        if (input.ContainsKey(inputKey))
                        {
                            p.Setter.Invoke(result, input[inputKey]);
                        }
                    });
                return result;
            }
        }
    }
