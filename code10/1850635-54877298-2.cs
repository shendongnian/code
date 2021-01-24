      public class InterfaceTableEntity : SNMPTableEntity
      {
        /// <summary>
        /// A unique value for each interface.  Its value ranges between 1 and the value of ifNumber.  The value for each interface must remain constant at least from one re-initialization of the entity's network management system to the next re- initialization.
        /// </summary>
        [SNMPProperty("1.3.6.1.2.1.2.2.1.1")]
        protected Integer32 ifIndex { get; set; }
        /// <summary>
        /// A textual string containing information about the interface.  This string should include the name of the manufacturer, the product name and the version of the hardware interface.
        /// </summary>
        [SNMPProperty("1.3.6.1.2.1.2.2.1.2")]
        protected OctetString ifDescr { get; set; }
        /// <summary>
        /// The type of interface, distinguished according to the physical/link protocol(s) immediately `below' the network layer in the protocol stack.
        /// </summary>
        [SNMPProperty("1.3.6.1.2.1.2.2.1.3")]
        protected Integer32 ifType { get; set; }
    }
