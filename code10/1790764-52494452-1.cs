    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Order order = new Order() {
                    credential = new Credential() { Domain = "MyDomain", Identity = "Me", SharedSecret = "I'm not Donald Trump" },
                    from = new From() { Credential = new Credential() { Domain = "MyDomain", Identity = "Me", SharedSecret = "I'm not Donald Trump" } },
                    to = new To() { Credential = new Credential() { Domain = "MyDomain", Identity = "Me", SharedSecret = "I'm not Donald Trump" } }
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serialize = new XmlSerializer(typeof(Order));
                serialize.Serialize(writer,order);
                writer.Close();
                XmlReader reader = XmlReader.Create(FILENAME);
                Order readOrder = (Order)serialize.Deserialize(reader);
            }
        }
        public class Order
        {
            public Credential credential { get; set; }
            public From from { get; set; }
            public To to { get; set; }
        }
        [XmlRoot(ElementName = "Credential")]
        public class Credential
        {
            [XmlElement(ElementName = "Identity")]
            public string Identity { get; set; }
            [XmlAttribute(AttributeName = "domain")]
            public string Domain { get; set; }
            [XmlElement(ElementName = "SharedSecret")]
            public string SharedSecret { get; set; }
        }
        [XmlRoot(ElementName = "From")]
        public class From
        {
            [XmlElement(ElementName = "Credential")]
            public Credential Credential { get; set; }
        }
        [XmlRoot(ElementName = "To")]
        public class To
        {
            [XmlElement(ElementName = "Credential")]
            public Credential Credential { get; set; }
        }
        [XmlRoot(ElementName = "Sender")]
        public class Sender
        {
            [XmlElement(ElementName = "Credential")]
            public Credential Credential { get; set; }
            [XmlElement(ElementName = "UserAgent")]
            public string UserAgent { get; set; }
        }
        [XmlRoot(ElementName = "Header")]
        public class Header
        {
            [XmlElement(ElementName = "From")]
            public From From { get; set; }
            [XmlElement(ElementName = "To")]
            public To To { get; set; }
            [XmlElement(ElementName = "Sender")]
            public Sender Sender { get; set; }
        }
        [XmlRoot(ElementName = "Money")]
        public class Money
        {
            [XmlAttribute(AttributeName = "currency")]
            public string Currency { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
        [XmlRoot(ElementName = "Total")]
        public class Total
        {
            [XmlElement(ElementName = "Money")]
            public Money Money { get; set; }
        }
        [XmlRoot(ElementName = "Name")]
        public class Name
        {
            [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
            public string Lang { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
        [XmlRoot(ElementName = "Country")]
        public class Country
        {
            [XmlAttribute(AttributeName = "isoCountryCode")]
            public string IsoCountryCode { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
        [XmlRoot(ElementName = "PostalAddress")]
        public class PostalAddress
        {
            [XmlElement(ElementName = "DeliverTo")]
            public string DeliverTo { get; set; }
            [XmlElement(ElementName = "Street")]
            public List<string> Street { get; set; }
            [XmlElement(ElementName = "City")]
            public string City { get; set; }
            [XmlElement(ElementName = "State")]
            public string State { get; set; }
            [XmlElement(ElementName = "PostalCode")]
            public string PostalCode { get; set; }
            [XmlElement(ElementName = "Country")]
            public Country Country { get; set; }
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
        }
        [XmlRoot(ElementName = "CountryCode")]
        public class CountryCode
        {
            [XmlAttribute(AttributeName = "isoCountryCode")]
            public string IsoCountryCode { get; set; }
        }
        [XmlRoot(ElementName = "TelephoneNumber")]
        public class TelephoneNumber
        {
            [XmlElement(ElementName = "CountryCode")]
            public CountryCode CountryCode { get; set; }
            [XmlElement(ElementName = "AreaOrCityCode")]
            public string AreaOrCityCode { get; set; }
            [XmlElement(ElementName = "Number")]
            public string Number { get; set; }
        }
        [XmlRoot(ElementName = "Phone")]
        public class Phone
        {
            [XmlElement(ElementName = "TelephoneNumber")]
            public TelephoneNumber TelephoneNumber { get; set; }
        }
        [XmlRoot(ElementName = "Fax")]
        public class Fax
        {
            [XmlElement(ElementName = "TelephoneNumber")]
            public TelephoneNumber TelephoneNumber { get; set; }
        }
        [XmlRoot(ElementName = "Address")]
        public class Address
        {
            [XmlElement(ElementName = "Name")]
            public Name Name { get; set; }
            [XmlElement(ElementName = "PostalAddress")]
            public PostalAddress PostalAddress { get; set; }
            [XmlElement(ElementName = "Email")]
            public string Email { get; set; }
            [XmlElement(ElementName = "Phone")]
            public Phone Phone { get; set; }
            [XmlElement(ElementName = "Fax")]
            public Fax Fax { get; set; }
            [XmlAttribute(AttributeName = "addressID")]
            public string AddressID { get; set; }
            [XmlAttribute(AttributeName = "isoCountryCode")]
            public string IsoCountryCode { get; set; }
        }
        [XmlRoot(ElementName = "ShipTo")]
        public class ShipTo
        {
            [XmlElement(ElementName = "Address")]
            public Address Address { get; set; }
        }
        [XmlRoot(ElementName = "BillTo")]
        public class BillTo
        {
            [XmlElement(ElementName = "Address")]
            public Address Address { get; set; }
        }
        [XmlRoot(ElementName = "Description")]
        public class Description
        {
            [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
            public string Lang { get; set; }
            [XmlText]
            public string Text { get; set; }
            [XmlElement(ElementName = "ShortName")]
            public string ShortName { get; set; }
        }
        [XmlRoot(ElementName = "Shipping")]
        public class Shipping
        {
            [XmlElement(ElementName = "Money")]
            public Money Money { get; set; }
            [XmlElement(ElementName = "Description")]
            public Description Description { get; set; }
            [XmlAttribute(AttributeName = "trackingDomain")]
            public string TrackingDomain { get; set; }
            [XmlAttribute(AttributeName = "trackingId")]
            public string TrackingId { get; set; }
        }
        [XmlRoot(ElementName = "TaxableAmount")]
        public class TaxableAmount
        {
            [XmlElement(ElementName = "Money")]
            public Money Money { get; set; }
        }
        [XmlRoot(ElementName = "TaxAmount")]
        public class TaxAmount
        {
            [XmlElement(ElementName = "Money")]
            public Money Money { get; set; }
        }
        [XmlRoot(ElementName = "TaxDetail")]
        public class TaxDetail
        {
            [XmlElement(ElementName = "TaxableAmount")]
            public TaxableAmount TaxableAmount { get; set; }
            [XmlElement(ElementName = "TaxAmount")]
            public TaxAmount TaxAmount { get; set; }
            [XmlElement(ElementName = "Description")]
            public Description Description { get; set; }
            [XmlAttribute(AttributeName = "category")]
            public string Category { get; set; }
            [XmlAttribute(AttributeName = "percentageRate")]
            public string PercentageRate { get; set; }
            [XmlAttribute(AttributeName = "purpose")]
            public string Purpose { get; set; }
        }
        [XmlRoot(ElementName = "Tax")]
        public class Tax
        {
            [XmlElement(ElementName = "Money")]
            public Money Money { get; set; }
            [XmlElement(ElementName = "Description")]
            public Description Description { get; set; }
            [XmlElement(ElementName = "TaxDetail")]
            public TaxDetail TaxDetail { get; set; }
        }
        [XmlRoot(ElementName = "DiscountPercent")]
        public class DiscountPercent
        {
            [XmlAttribute(AttributeName = "percent")]
            public string Percent { get; set; }
        }
        [XmlRoot(ElementName = "Discount")]
        public class Discount
        {
            [XmlElement(ElementName = "DiscountPercent")]
            public DiscountPercent DiscountPercent { get; set; }
        }
        [XmlRoot(ElementName = "PaymentTerm")]
        public class PaymentTerm
        {
            [XmlElement(ElementName = "Discount")]
            public Discount Discount { get; set; }
            [XmlAttribute(AttributeName = "payInNumberOfDays")]
            public string PayInNumberOfDays { get; set; }
        }
        [XmlRoot(ElementName = "Comments")]
        public class Comments
        {
            [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
            public string Lang { get; set; }
        }
        [XmlRoot(ElementName = "Extrinsic")]
        public class Extrinsic
        {
            [XmlAttribute(AttributeName = "name")]
            public string Name { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
        [XmlRoot(ElementName = "OrderRequestHeader")]
        public class OrderRequestHeader
        {
            [XmlElement(ElementName = "Total")]
            public Total Total { get; set; }
            [XmlElement(ElementName = "ShipTo")]
            public ShipTo ShipTo { get; set; }
            [XmlElement(ElementName = "BillTo")]
            public BillTo BillTo { get; set; }
            [XmlElement(ElementName = "Shipping")]
            public Shipping Shipping { get; set; }
            [XmlElement(ElementName = "Tax")]
            public Tax Tax { get; set; }
            [XmlElement(ElementName = "PaymentTerm")]
            public List<PaymentTerm> PaymentTerm { get; set; }
            [XmlElement(ElementName = "Comments")]
            public Comments Comments { get; set; }
            [XmlElement(ElementName = "Extrinsic")]
            public List<Extrinsic> Extrinsic { get; set; }
            [XmlAttribute(AttributeName = "orderDate")]
            public string OrderDate { get; set; }
            [XmlAttribute(AttributeName = "orderID")]
            public string OrderID { get; set; }
            [XmlAttribute(AttributeName = "orderType")]
            public string OrderType { get; set; }
            [XmlAttribute(AttributeName = "type")]
            public string Type { get; set; }
        }
        [XmlRoot(ElementName = "ItemID")]
        public class ItemID
        {
            [XmlElement(ElementName = "SupplierPartID")]
            public string SupplierPartID { get; set; }
        }
        [XmlRoot(ElementName = "UnitPrice")]
        public class UnitPrice
        {
            [XmlElement(ElementName = "Money")]
            public Money Money { get; set; }
        }
        [XmlRoot(ElementName = "Classification")]
        public class Classification
        {
            [XmlAttribute(AttributeName = "domain")]
            public string Domain { get; set; }
            [XmlText]
            public string Text { get; set; }
        }
        [XmlRoot(ElementName = "ItemDetail")]
        public class ItemDetail
        {
            [XmlElement(ElementName = "UnitPrice")]
            public UnitPrice UnitPrice { get; set; }
            [XmlElement(ElementName = "Description")]
            public Description Description { get; set; }
            [XmlElement(ElementName = "UnitOfMeasure")]
            public string UnitOfMeasure { get; set; }
            [XmlElement(ElementName = "Classification")]
            public Classification Classification { get; set; }
            [XmlElement(ElementName = "ManufacturerPartID")]
            public string ManufacturerPartID { get; set; }
            [XmlElement(ElementName = "ManufacturerName")]
            public string ManufacturerName { get; set; }
            [XmlElement(ElementName = "LeadTime")]
            public string LeadTime { get; set; }
            [XmlElement(ElementName = "Extrinsic")]
            public List<Extrinsic> Extrinsic { get; set; }
        }
        [XmlRoot(ElementName = "ItemOut")]
        public class ItemOut
        {
            [XmlElement(ElementName = "ItemID")]
            public ItemID ItemID { get; set; }
            [XmlElement(ElementName = "ItemDetail")]
            public ItemDetail ItemDetail { get; set; }
            [XmlElement(ElementName = "Tax")]
            public Tax Tax { get; set; }
            [XmlElement(ElementName = "Comments")]
            public Comments Comments { get; set; }
            [XmlAttribute(AttributeName = "lineNumber")]
            public string LineNumber { get; set; }
            [XmlAttribute(AttributeName = "quantity")]
            public string Quantity { get; set; }
            [XmlAttribute(AttributeName = "requestedDeliveryDate")]
            public string RequestedDeliveryDate { get; set; }
            [XmlAttribute(AttributeName = "requisitionID")]
            public string RequisitionID { get; set; }
        }
        [XmlRoot(ElementName = "OrderRequest")]
        public class OrderRequest
        {
            [XmlElement(ElementName = "OrderRequestHeader")]
            public OrderRequestHeader OrderRequestHeader { get; set; }
            [XmlElement(ElementName = "ItemOut")]
            public List<ItemOut> ItemOut { get; set; }
        }
        [XmlRoot(ElementName = "Request")]
        public class Request
        {
            [XmlElement(ElementName = "OrderRequest")]
            public OrderRequest OrderRequest { get; set; }
        }
        [XmlRoot(ElementName = "cXML")]
        public class CXML
        {
            [XmlElement(ElementName = "Header")]
            public Header Header { get; set; }
            [XmlElement(ElementName = "Request")]
            public Request Request { get; set; }
            [XmlAttribute(AttributeName = "payloadID")]
            public string PayloadID { get; set; }
            [XmlAttribute(AttributeName = "timestamp")]
            public string Timestamp { get; set; }
            [XmlAttribute(AttributeName = "lang", Namespace = "http://www.w3.org/XML/1998/namespace")]
            public string Lang { get; set; }
        }
    }
