        public class ParameterizedProperties
        {
            // Parameterized properties
            private Property<int> m_IntProp = new Property<int>();
            private Property<string> m_StringProp = new Property<string>();
            // Parameterized int property accessor for client access
            //  (ex: ParameterizedProperties.PublicIntProp[index])
            public Property<int> PublicIntProp
            {
                get { return m_IntProp; }
            }
            // Parameterized string property accessor
            //  (ex: ParameterizedProperties.PublicStringProp[index])
            public Property<string> PublicStringProp
            {
                get { return m_StringProp; }
            }
        }
