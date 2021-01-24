        // The XmlTypeAttribute.Namespace below must be initialized to something if it is also initialized on the derived type.
        // However, the actual value does not need to be the same as the child's namespace, so modify to be something more appropriate
        // based on additional XML samples.
        [XmlType("CLUSTER", Namespace = "")] 
        [XmlInclude(typeof(ClusterType))]
        // Add XmlInclude for all additional subtypes here.
        public class Cluster
        {
            // Remainder unchanged
    If the base type XML namespace is not set, `XmlSerializer` will throw an exception with a misleading message:
     > System.InvalidOperationException: There was an error generating the XML document. ---> System.InvalidOperationException: The type Fibextoobject+ClusterType was not expected. Use the XmlInclude or SoapInclude attribute to specify types that are not known statically.
    Since `ClusterType` is in fact included via `[XmlInclude]` the message is not helpful.  It took a bit of experimentation to determine the actual problem.
