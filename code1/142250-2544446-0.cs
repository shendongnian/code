    global::Command o;
    o = new global::Command();
    if ((object)(o.@To) == null) o.@To = new global::System.Collections.Generic.List<global::Parameter>();
    global::System.Collections.Generic.List<global::Parameter> a_0 = (global::System.Collections.Generic.List<global::Parameter>)o.@To;
    // code elided
    //...
    while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
      if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
        if (((object)Reader.LocalName == (object)id4_To && (object)Reader.NamespaceURI == (object)id2_Item)) {
          if (!ReadNull()) {
            if ((object)(o.@To) == null) o.@To = new global::System.Collections.Generic.List<global::Parameter>();
            global::System.Collections.Generic.List<global::Parameter> a_0_0 = (global::System.Collections.Generic.List<global::Parameter>)o.@To;
            // code elided
            //...
          }
          else {
            // Problem here:
            if ((object)(o.@To) == null) o.@To = new global::System.Collections.Generic.List<global::Parameter>();
            global::System.Collections.Generic.List<global::Parameter> a_0_0 = (global::System.Collections.Generic.List<global::Parameter>)o.@To;
          }
        }
      }
      Reader.MoveToContent();
      CheckReaderCount(ref whileIterations1, ref readerCount1);
    }
    ReadEndElement();
    return o;
