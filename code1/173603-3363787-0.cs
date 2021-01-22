    public abstract class EntityXmlParser
    {
    	public abstract bool isValueExists(params string[] arrParamName);
    	public abstract string GetSingleValue(string sParamName, string sDefaultValue);
    	public abstract int GetSingleValue(string sParamName, int nDefaultValue);
    	public abstract decimal GetSingleValue(string sParamName, decimal nDefaultValue);
    	public abstract Guid GetSingleValue(string sParamName, Guid idDefaultValue);
    	public abstract DateTime GetSingleValue(string sParamName, DateTime dtDefaultValue);
    }
    public class EntityCrmCalloutXmlParser : EntityXmlParser
    {
    	private XmlDocument m_xmlDoc = null;
    	private NameTable m_xmlNameTable = null;
    	private XmlNamespaceManager m_xmlNameMgr = null;
    	private const string ms_sURIXmlns = @"http://schemas.microsoft.com/crm/2006/WebServices";
    	private const string ms_sURIXsi = @"http://www.w3.org/2001/XMLSchema-instance";
    	private bool m_blChangeEntityXml = false;
	public EntityCrmCalloutXmlParser(string sCalloutEntityXml)
	{
		/*m_xd = new XPathDocument(new System.IO.StringReader(sCalloutEntityXml));
		m_xn = m_xd.CreateNavigator();*/
		m_xmlNameTable = new NameTable();
		m_xmlNameMgr = new XmlNamespaceManager(m_xmlNameTable);
		// Add the required prefix/namespace pairs to the namespace manager. Add a default namespace first.
		m_xmlNameMgr.AddNamespace("crm", ms_sURIXmlns);
		m_xmlNameMgr.AddNamespace("xsi", ms_sURIXsi);
		// загрузка xml-строки
		m_xmlDoc = new XmlDocument();
		m_xmlDoc.LoadXml(sCalloutEntityXml);
	}
	public string EntityXml
	{
		get { return m_xmlDoc.OuterXml; }
	}
	public bool IsChangeEntityXml
	{
		get { return m_blChangeEntityXml; }
	}
	
	public string GetEntityName()
	{
		XmlNodeList xmllstItem = m_xmlDoc.SelectNodes("/crm:BusinessEntity/@Name", m_xmlNameMgr);
		if ((null == xmllstItem) || (1 != xmllstItem.Count))
			throw new CrmInternalException("Название сущности не найдено.");
		return xmllstItem[0].InnerText;
	}
   
	public override string GetSingleValue(string sParamName, string sDefaultValue)
	{
		XmlNodeList xiter = m_xmlDoc.SelectNodes("//crm:Property[@Name='" + sParamName + "']/crm:Value", m_xmlNameMgr);
		if (0 == xiter.Count)
			return sDefaultValue;
		if ((1 != xiter.Count) /* || !xiter.MoveNext()*/)
			throw new System.ApplicationException("Ошибка при разборе входных значений. Неудалось однозначно определить параметр '" + sParamName + "'.");
		// проверка на значение null.
		XmlAttribute xmlIsNullAttribute = xiter.Item(0).Attributes["IsNull"];
		bool blNull = false;
		if (null != xmlIsNullAttribute)
			blNull = bool.Parse(xiter.Item(0).Attributes["IsNull"].Value);
		return (blNull) ? sDefaultValue : xiter.Item(0).InnerText;
	}
	public override Guid GetSingleValue(string sParamName, Guid idDefaultValue)
	{
		return new Guid(GetSingleValue(sParamName, idDefaultValue.ToString("B")));
	}
	public override decimal GetSingleValue(string sParamName, decimal nDefaultValue)
	{
		return decimal.Parse(GetSingleValue(sParamName, nDefaultValue.ToString(CalloutManager.Instance.NumberFormatInfo)), CalloutManager.Instance.NumberFormatInfo);
	}
	public override int GetSingleValue(string sParamName, int nDefaultValue)
	{
		return int.Parse(GetSingleValue(sParamName, nDefaultValue.ToString()));
	}
	public override DateTime GetSingleValue(string sParamName, DateTime dtDefaultValue)
	{
		return DateTime.Parse(GetSingleValue(sParamName, dtDefaultValue.ToString(CalloutManager.Instance.CRMFullDateFormat)));
	}
		public bool SetPropertyValue(string sPropertyName, DateTime dtPropertyValue)
		{
			XmlNode xmlRootPropNode = m_xmlDoc.SelectSingleNode("crm:BusinessEntity/crm:Properties", m_xmlNameMgr);
			if (null == xmlRootPropNode)
				throw new ApplicationException("Ошибка при получении xml элемента BusinessEntity.");
			// поиск элемента в xml-структуре
			XmlElement xmlPropValueElem = (XmlElement)xmlRootPropNode.SelectSingleNode("crm:Property[@Name='" + sPropertyName + @"']/crm:Value", m_xmlNameMgr);
			if (null == xmlPropValueElem)
			{	// элемент не найден
				// создание элемента
				XmlElement xmlPropElem = (XmlElement)xmlRootPropNode.AppendChild(m_xmlDoc.CreateElement("Property", ms_sURIXmlns));
				xmlPropElem.SetAttribute("type", ms_sURIXsi, "CrmDateTimeProperty");
				xmlPropElem.SetAttribute("Name", sPropertyName);
				xmlPropValueElem = (XmlElement)xmlPropElem.AppendChild(m_xmlDoc.CreateElement("Value", ms_sURIXmlns));
			}
			if (DateTime.MinValue.Equals(dtPropertyValue))
				xmlPropValueElem.SetAttribute("IsNull", string.Empty, "true");
			else
				xmlPropValueElem.InnerText = dtPropertyValue.ToString("s");
			m_blChangeEntityXml = true;
			return true;
		}
		public bool SetPropertyValue(string sPropertyName, string sPropertyValue)
		{
			XmlNode xmlRootPropNode = m_xmlDoc.SelectSingleNode("crm:BusinessEntity/crm:Properties", m_xmlNameMgr);
			if (null == xmlRootPropNode)
				throw new ApplicationException("Ошибка при получении xml элемента BusinessEntity.");
			// поиск элемента в xml-структуре
			XmlElement xmlPropValueElem = (XmlElement)xmlRootPropNode.SelectSingleNode("crm:Property[@Name='" + sPropertyName + @"']/crm:Value", m_xmlNameMgr);
			if (null == xmlPropValueElem)
			{	// элемент не найден
				// создание элемента
				XmlElement xmlPropElem = (XmlElement)xmlRootPropNode.AppendChild(m_xmlDoc.CreateElement("Property", ms_sURIXmlns));
				xmlPropElem.SetAttribute("type", ms_sURIXsi, "StringProperty");
				xmlPropElem.SetAttribute("Name", sPropertyName);
				xmlPropValueElem = (XmlElement)xmlPropElem.AppendChild(m_xmlDoc.CreateElement("Value", ms_sURIXmlns));
			}
			xmlPropValueElem.InnerText = sPropertyValue;
			m_blChangeEntityXml = true;
			return true;
		}
		public bool SetPropertyValue(string sPropertyName, Guid idPropertyValue)
		{
			XmlNode xmlRootPropNode = m_xmlDoc.SelectSingleNode("crm:BusinessEntity/crm:Properties", m_xmlNameMgr);
			if (null == xmlRootPropNode)
				throw new CrmInternalException("Ошибка при получении xml элемента BusinessEntity.");
			// поиск элемента в xml-структуре
			XmlElement xmlPropValueElem = (XmlElement)xmlRootPropNode.SelectSingleNode("crm:Property[@Name='" + sPropertyName + @"']/crm:Value", m_xmlNameMgr);
			if (null == xmlPropValueElem)
			{	// элемент не найден
				// создание элемента
				XmlElement xmlPropElem = (XmlElement)xmlRootPropNode.AppendChild(m_xmlDoc.CreateElement("Property", ms_sURIXmlns));
				xmlPropElem.SetAttribute("type", ms_sURIXsi, "LookupProperty");
				xmlPropElem.SetAttribute("Name", sPropertyName);
				xmlPropValueElem = (XmlElement)xmlPropElem.AppendChild(m_xmlDoc.CreateElement("Value", ms_sURIXmlns));
			}
			if (idPropertyValue.Equals(Guid.Empty))
				xmlPropValueElem.SetAttribute("IsNull", string.Empty, "true");
			else
				xmlPropValueElem.InnerText = idPropertyValue.ToString("B");
			m_blChangeEntityXml = true;
			return true;
		}
		public bool SetPropertyValue(string sPropertyName, int nPropertyValue)
		{
			XmlNode xmlRootPropNode = m_xmlDoc.SelectSingleNode("crm:BusinessEntity/crm:Properties", m_xmlNameMgr);
			if (null == xmlRootPropNode)
				throw new CrmInternalException("Ошибка при получении xml элемента BusinessEntity.");
			// поиск элемента в xml-структуре
			XmlElement xmlPropValueElem = (XmlElement)xmlRootPropNode.SelectSingleNode("crm:Property[@Name='" + sPropertyName + @"']/crm:Value", m_xmlNameMgr);
			if (null == xmlPropValueElem)
			{	// элемент не найден
				// создание элемента
				XmlElement xmlPropElem = (XmlElement)xmlRootPropNode.AppendChild(m_xmlDoc.CreateElement("Property", ms_sURIXmlns));
				xmlPropElem.SetAttribute("type", ms_sURIXsi, "CrmNumberProperty");
				xmlPropElem.SetAttribute("Name", sPropertyName);
				xmlPropValueElem = (XmlElement)xmlPropElem.AppendChild(m_xmlDoc.CreateElement("Value", ms_sURIXmlns));
			}
			xmlPropValueElem.InnerText = nPropertyValue.ToString();
			m_blChangeEntityXml = true;
			return true;
		}
		public bool SetPropertyValue(string sPropertyName, decimal dPropertyValue)
		{
			XmlNode xmlRootPropNode = m_xmlDoc.SelectSingleNode("crm:BusinessEntity/crm:Properties", m_xmlNameMgr);
			if (null == xmlRootPropNode)
				throw new CrmInternalException("Ошибка при получении xml элемента BusinessEntity.");
			// поиск элемента в xml-структуре
			XmlElement xmlPropValueElem = (XmlElement)xmlRootPropNode.SelectSingleNode("crm:Property[@Name='" + sPropertyName + @"']/crm:Value", m_xmlNameMgr);
			if (null == xmlPropValueElem)
			{	// элемент не найден
				// создание элемента
				XmlElement xmlPropElem = (XmlElement)xmlRootPropNode.AppendChild(m_xmlDoc.CreateElement("Property", ms_sURIXmlns));
				xmlPropElem.SetAttribute("type", ms_sURIXsi, "CrmMoneyProperty");
				xmlPropElem.SetAttribute("Name", sPropertyName);
				xmlPropValueElem = (XmlElement)xmlPropElem.AppendChild(m_xmlDoc.CreateElement("Value", ms_sURIXmlns));
			}
			xmlPropValueElem.InnerText = dPropertyValue.ToString(System.Globalization.CultureInfo.InvariantCulture);
			m_blChangeEntityXml = true;
			return true;
		}
	}
 	
}
