string XmlConvert(string sXml, bool ToXml){
    string sConvertd = string.Empty;
    if (ToXml){
       sConvertd = sXml.Replace("&lt;", "#lt;").Replace("&gt;", "#gt;").Replace("&amp;", "#amp;");
    }else{
       sConvertd = sXml.Replace("#lt;", "&lt;").Replace("#gt;", "&gt;").Replace("#amp;", "&amp;");
    }
    return sConvertd;
}
