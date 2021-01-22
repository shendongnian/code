foreach(XmlNode node in XmlNodes){
     if (node["holder"].HasAttribues != null && node["holder"].Attributes.Count &gt;1){
        for (int i = 0; i &lt; node["holder"].Attributes.Count; i++){
             try{
                XmlAttribute attr = node["holder"].Attributes[i];
                if (attr != null){
                     ....
                }
             }catch(XmlException xmlEx){
                // Do something here with this...output to log?
             }
        }
     }
}
