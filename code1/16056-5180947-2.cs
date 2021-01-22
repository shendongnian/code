    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    
    
    namespace ConsoleApplication1 {
    
        public class XmlReaderSpy : XmlReader {
            XmlReader _me;
            public XmlReaderSpy(XmlReader parent) {
                _me = parent;
            }
    
            /// <summary>
            /// Extracted XML.
            /// </summary>
            public string Xml;
    
            #region Abstract method that must be implemented
            public override XmlNodeType NodeType {
                get {
    
                    return _me.NodeType;
                }
            }
    
            public override string LocalName {
                get {
                    return _me.LocalName;
                }
            }
    
            public override string NamespaceURI {
                get {
                    return _me.NamespaceURI;
                }
            }
    
            public override string Prefix {
                get {
                    return _me.Prefix;
                }
            }
    
            public override bool HasValue {
                get { return _me.HasValue; }
            }
    
            public override string Value {
                get { return _me.Value; }
            }
    
            public override int Depth {
                get { return _me.Depth; }
            }
    
            public override string BaseURI {
                get { return _me.BaseURI; }
            }
    
            public override bool IsEmptyElement {
                get { return _me.IsEmptyElement; }
            }
    
            public override int AttributeCount {
                get { return _me.AttributeCount; }
            }
    
            public override string GetAttribute(int i) {
                return _me.GetAttribute(i);
            }
    
            public override string GetAttribute(string name) {
                return _me.GetAttribute(name);
            }
    
            public override string GetAttribute(string name, string namespaceURI) {
                return _me.GetAttribute(name, namespaceURI);
            }
    
            public override void MoveToAttribute(int i) {
                _me.MoveToAttribute(i);
            }
    
            public override bool MoveToAttribute(string name) {
                return _me.MoveToAttribute(name);
            }
    
            public override bool MoveToAttribute(string name, string ns) {
                return _me.MoveToAttribute(name, ns);
            }
    
            public override bool MoveToFirstAttribute() {
                return _me.MoveToFirstAttribute();
            }
    
            public override bool MoveToNextAttribute() {
                return _me.MoveToNextAttribute();
            }
    
            public override bool MoveToElement() {
                return _me.MoveToElement();
            }
    
            public override bool ReadAttributeValue() {
                return _me.ReadAttributeValue();
            }
    
            public override bool Read() {
                bool res = _me.Read();
    
                Xml += StringView();
    
    
                return res;
            }
    
            public override bool EOF {
                get { return _me.EOF; }
            }
    
            public override void Close() {
                _me.Close();
            }
    
            public override ReadState ReadState {
                get { return _me.ReadState; }
            }
    
            public override XmlNameTable NameTable {
                get { return _me.NameTable; }
            }
    
            public override string LookupNamespace(string prefix) {
                return _me.LookupNamespace(prefix);
            }
    
            public override void ResolveEntity() {
                _me.ResolveEntity();
            }
    
            #endregion
    
         
            protected string StringView() {
                string result = "";
    
                if (_me.NodeType == XmlNodeType.Element) {
                    result = "<" + _me.Name;
    
                    if (_me.HasAttributes) {
                        _me.MoveToFirstAttribute();
                        do {
                            result += " " + _me.Name + "=\"" + _me.Value + "\"";
                        } while (_me.MoveToNextAttribute());
    
                        //Let's put cursor back to Element to avoid messing up reader state.
                        _me.MoveToElement();
                    }
    
                    if (_me.IsEmptyElement) {
                        result += "/";
                    }
    
                    result += ">";
                }
    
                if (_me.NodeType == XmlNodeType.EndElement) {
                    result = "</" + _me.Name + ">";
                }
    
                if (_me.NodeType == XmlNodeType.Text || _me.NodeType == XmlNodeType.Whitespace) {
                    result = _me.Value;
                }
    
    
    
                if (_me.NodeType == XmlNodeType.XmlDeclaration) {
                    result = "<?"  + _me.Name + " " +   _me.Value + "?>";
                }
    
                return result;
    
            }
        }
        
        public class MyInfo : ConsoleApplication1.eu.dataaccess.footballpool.Info {             
    
            protected XmlReaderSpy _xmlReaderSpy;
    
            public string Xml {
                get {
                    if (_xmlReaderSpy != null) {
                        return _xmlReaderSpy.Xml;
                    }
                    else {
                        return "";
                    }
                }
            }
    
    
            protected override XmlReader GetReaderForMessage(System.Web.Services.Protocols.SoapClientMessage message, int bufferSize) {          
                XmlReader rdr = base.GetReaderForMessage(message, bufferSize);
                _xmlReaderSpy = new XmlReaderSpy((XmlReader)rdr);
                return _xmlReaderSpy;
            }
    
        }
    
        class Program {
            static void Main(string[] args) {
    
                MyInfo info = new MyInfo();
                string[] rest = info.Cities();
    
                System.Console.WriteLine("RAW Soap XML response :\n"+info.Xml);
                System.Console.ReadLine();
            }
        }
    }
