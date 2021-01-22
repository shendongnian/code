            public void Open(string filename)
            {
                
                // Create serializer
                XmlSerializer serializer = new XmlSerializer(typeof(ObjectType));
    
                // Set event handlers for unknown nodes/attributes
                serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
                serializer.UnknownAttribute += new  XmlAttributeEventHandler(serializer_UnknownAttribute);
                
    ...
    
            }
    
            private static void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e)
            {
                throw new System.NotImplementedException();
            }
    
            private static void serializer_UnknownNode(object sender, XmlNodeEventArgs e)
            {
                throw new System.NotImplementedException();
            }
