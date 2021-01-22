    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace XmlTester
    {
     public class Program {
      static void Main(string[] args) {
       Console.WriteLine("XML tester...");
    
    // Valid XML for an ItemList of Person's
    XmlSerializer ser = new XmlSerializer(typeof(ItemList<Person>));
    string xmlIn =
    @"<ItemList xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
     <PersonBilingual>
      <FullName>John Smith</FullName>
      <Age>21</Age>
      <Language>French</Language>
      <SecondLanguage>German</SecondLanguage>
     </PersonBilingual>
     <Person>
      <FullName>Joe Bloggs</FullName>
      <Age>26</Age>
      <Language>English</Language>
     </Person>
     <Person i:type=""PersonBilingual"">
      <FullName>Jane Doe</FullName>
      <Age>78</Age>
      <Language>Italian</Language>
      <SecondLanguage>English</SecondLanguage>
     </Person>
    </ItemList>";
    
    //// Valid XML for an ItemList of Account's
    //XmlSerializer ser = new XmlSerializer(typeof(ItemList<Account>));
    //string xmlIn =
    //@"<ItemList xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
    // <AccountBank>
    //  <AcctName>Deposit account</AcctName>
    //  <WithCompany>Bank of Switzerland</WithCompany>
    //  <BalanceInEuros>300</BalanceInEuros>
    // </AccountBank>
    // <Account>
    //  <AcctName>Book buying account</AcctName>
    //  <WithCompany>Amazon</WithCompany>
    // </Account>
    // <Account i:type=""AccountBank"">
    //  <AcctName>Savings account</AcctName>
    //  <WithCompany>Bank of America</WithCompany>
    //  <BalanceInEuros>2500</BalanceInEuros>
    // </Account>
    //</ItemList>";
    
    //// Invalid XML, as we have mixed incompatible types
    //XmlSerializer ser = new XmlSerializer(typeof(ItemList<Person>));
    //string xmlIn =
    //@"<ItemList xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
    // <PersonBilingual>
    //  <FullName>John Smith</FullName>
    //  <Age>21</Age>
    //  <Language>French</Language>
    //  <SecondLanguage>German</SecondLanguage>
    // </PersonBilingual>
    // <Account>
    //  <AcctName>Book buying account</AcctName>
    //  <WithCompany>Amazon</WithCompany>
    // </Account>
    // <Person i:type=""PersonBilingual"">
    //  <FullName>Jane Doe</FullName>
    //  <Age>78</Age>
    //  <Language>Italian</Language>
    //  <SecondLanguage>English</SecondLanguage>
    // </Person>
    //</ItemList>";
    
       // Deserialize...
       ItemList<Person> result;
       using (var reader = new StringReader(xmlIn)) {
        result = (ItemList<Person>)ser.Deserialize(reader);
       }
       
       Console.WriteLine("Break here and check 'result' in Quickwatch...");
       Console.ReadKey();
       
       // Serialize...
       StringBuilder xmlOut = new StringBuilder();
       ser.Serialize(new StringWriter(xmlOut), result);
       
       Console.WriteLine("Break here and check 'xmlOut' in Quickwatch...");
       Console.ReadKey();
      }
     }
     
     [XmlRoot(ElementName = "ItemList", IsNullable = false)]
     [XmlInclude(typeof(Person))]
     [XmlInclude(typeof(PersonBilingual))]
     [XmlInclude(typeof(Account))]
     [XmlInclude(typeof(AccountBank))]
     public class ItemList<T> : IXmlSerializable {
      #region Private vars
      
      /// <summary>
      /// The class that will store our serializers for the various classes that may be (de)serialized, given
      /// the type of this ItemList (ie. the type itself, as well as any type that extends the type)
      /// </summary>
      private class Map : Dictionary<string, XmlSerializer> { public Map() : base(StringComparer.Ordinal) { } }
      
      #endregion
      
      #region Private methods
      
      /// <summary>
      /// Creates a 'schema' for this ItemList, using its type, and the XmlIncludeAttribute types that are
      /// associated with it.  For each XmlIncludeAttribute, if it can be assigned to this ItemList's type (so
      /// it's either the same type as this ItemList's type or a type that extends this ItemList's type), adds
      /// the XmlSerializer for that XmlIncludeAttribute's type to our 'schema' collection, allowing a node
      /// corresponding to that type to be (de)serialized by this ItemList.
      /// </summary>
      /// <returns>The 'schema' containing the XmlSerializer's available for this ItemList to use during (de)serialization.</returns>
      private Map loadSchema() {
       Map map = new Map();
       foreach (XmlIncludeAttribute inc in typeof(ItemList<T>).GetCustomAttributes(typeof(XmlIncludeAttribute), true)) {
        Type t = inc.Type;
        if (typeof(T).IsAssignableFrom(t)) { map.Add(xmlTypeName(t), new XmlSerializer(t)); }
       }
       return map;
      }
      
      /// <summary>
      /// As the XML type name can be different to our internal class name for that XML type, we need to be able
      /// to expect an XML element name that is different to our internal class name for that XML type.  Hence,
      /// our 'schema' map will contain XmlSerializer's whose keys are based on the XML type name, NOT our
      /// internal class name for that XML type.  This method returns the XML type name given our internal
      /// class we're using to (de)serialize that XML type.  If no XML TypeName is specified in our internal
      /// class's XmlTypeAttribute, we assume an XML type name identical to the internal class name.
      /// </summary>
      /// <param name="t">Our internal class used to (de)serialize an XML type.</param>
      /// <returns>The XML type name corresponding to the given internal class.</returns>
      private string xmlTypeName(Type t) {
       string typeName = t.Name;
       foreach (XmlTypeAttribute ta in t.GetCustomAttributes(typeof(XmlTypeAttribute), true)) {
        if (!string.IsNullOrEmpty(ta.TypeName)) { typeName = ta.TypeName; }
       }
       return typeName;
      }
      
      #endregion
      
      #region IXmlSerializable Members
      
      /// <summary>
      /// Reserved and should not be used.
      /// </summary>
      /// <returns>Must return null.</returns>
      public XmlSchema GetSchema() {
       return null;
      }
      
      /// <summary>
      /// Generates a list of type T objects from their XML representation; stores them in this.Items.
      /// </summary>
      /// <param name="reader">The System.Xml.XmlReader stream from which the objects are deserialized.</param>
      public void ReadXml(XmlReader reader) {
       Map map = loadSchema();
       int depth = reader.Depth;
       
       List<T> items = new List<T>();
       if (!reader.IsEmptyElement && reader.Read()) {
        // While the reader is at a greater depth that the initial depth, ie. at one of the elements
        // inside the list wrapper, the initial depth being that of the list wrapper <ItemList>...
        while (reader.Depth > depth) {
         try { items.Add((T)map[reader.LocalName].Deserialize(reader)); }
         catch (InvalidOperationException iopEx) {
          if (
           iopEx.InnerException != null &&
           iopEx.InnerException.Message.StartsWith("The specified type was not recognized")
          ) { throw new InvalidOperationException("Couldn't deserialize node '" + reader.LocalName + "' because although its element node is a valid type, its attribute-specified type was not recognized.  Perhaps it needs adding to the ItemList using XmlIncludeAttribute?", iopEx); }
         }
         catch (KeyNotFoundException knfEx) {
          throw new InvalidOperationException("Couldn't deserialize node '" + reader.LocalName + "' because its element node was not recognized as a valid type.  Perhaps it needs adding to the ItemList using XmlIncludeAttribute?", knfEx);
         }
         catch (Exception ex) {
          throw ex;
         }
        }
       }
       this.Items = items;
      }
      
      /// <summary>
      /// Converts a list of type T objects into their XML representation; writes them to the specified writer.
      /// </summary>
      /// <param name="writer">The System.Xml.XmlWriter stream to which the objects are serialized.</param>
      public void WriteXml(XmlWriter writer) {
       Map map = loadSchema();
       foreach (T item in this.Items) {
        map[xmlTypeName(item.GetType())].Serialize(writer, item);
       }
      }
      
      #endregion
      
      #region Public properties
      
      public List<T> Items { get; set; }
      
      #endregion
     }
     
     /// <summary>
     /// A regular person.
     /// </summary>
     [XmlType(AnonymousType = false, TypeName = "Person", Namespace = "")]
     [XmlInclude(typeof(PersonBilingual))]
     public class Person {
      public string FullName { get; set; }
      public int Age { get; set; }
      public string Language { get; set; }
     }
     
     /// <summary>
     /// A person who can speak a second language.
     /// </summary>
     [XmlType(AnonymousType = false, TypeName = "PersonBilingual", Namespace = "")]
     public class PersonBilingual : Person {
      public string SecondLanguage { get; set; }
     }
     
     /// <summary>
     /// Some kind of account.
     /// </summary>
     [XmlType(AnonymousType = false, TypeName = "Account", Namespace = "")]
     [XmlInclude(typeof(AccountBank))]
     public class Account {
      public string AcctName { get; set; }
      public string WithCompany { get; set; }
     }
     
     /// <summary>
     /// A bank account.
     /// </summary>
     [XmlType(AnonymousType = false, TypeName = "AccountBank", Namespace = "")]
     public class AccountBank : Account {
      public int BalanceInEuros { get; set; }
     }
    }
