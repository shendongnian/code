    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="InvoiceTypeCode", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    	public class InvoiceTypeCode {
    		[XmlAttribute(AttributeName="listID")]
    		public string ListID { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="DocumentCurrencyCode", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    	public class DocumentCurrencyCode {
    		[XmlAttribute(AttributeName="listID")]
    		public string ListID { get; set; }
    		[XmlText]
    		public string Text { get; set; }
    	}
    
    	[XmlRoot(ElementName="InvoicePeriod", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    	public class InvoicePeriod {
    		[XmlElement(ElementName="StartDate", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string StartDate { get; set; }
    		[XmlElement(ElementName="EndDate", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string EndDate { get; set; }
    	}
    
    	[XmlRoot(ElementName="Invoice", Namespace="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2")]
    	public class Invoice {
    		[XmlElement(ElementName="UBLVersionID", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string UBLVersionID { get; set; }
    		[XmlElement(ElementName="CustomizationID", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string CustomizationID { get; set; }
    		[XmlElement(ElementName="ProfileID", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string ProfileID { get; set; }
    		[XmlElement(ElementName="ID", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string ID { get; set; }
    		[XmlElement(ElementName="IssueDate", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string IssueDate { get; set; }
    		[XmlElement(ElementName="InvoiceTypeCode", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public InvoiceTypeCode InvoiceTypeCode { get; set; }
    		[XmlElement(ElementName="Note", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string Note { get; set; }
    		[XmlElement(ElementName="TaxPointDate", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string TaxPointDate { get; set; }
    		[XmlElement(ElementName="DocumentCurrencyCode", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public DocumentCurrencyCode DocumentCurrencyCode { get; set; }
    		[XmlElement(ElementName="AccountingCost", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2")]
    		public string AccountingCost { get; set; }
    		[XmlElement(ElementName="InvoicePeriod", Namespace="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2")]
    		public InvoicePeriod InvoicePeriod { get; set; }
    		[XmlAttribute(AttributeName="xmlns")]
    		public string Xmlns { get; set; }
    		[XmlAttribute(AttributeName="cac", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Cac { get; set; }
    		[XmlAttribute(AttributeName="cbc", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Cbc { get; set; }
    		[XmlAttribute(AttributeName="ccts", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Ccts { get; set; }
    		[XmlAttribute(AttributeName="qdt", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Qdt { get; set; }
    		[XmlAttribute(AttributeName="udt", Namespace="http://www.w3.org/2000/xmlns/")]
    		public string Udt { get; set; }
    	}
    
    }
