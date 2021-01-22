    public static void AddEvent(MyCustomBeanClass e, SPSite site)
    {
    	StringWriter sw = new StringWriter();
    	XmlSerializer xs = new XmlSerializer(typeof(MyCustomBeanClass));
    	xs.Serialize(sw, e);
    	site.Audit.WriteAuditEvent(SPAuditEventType.Custom, "MyCustomAuditing", sw.ToString());
    }
