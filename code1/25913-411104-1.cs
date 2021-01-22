    IFormatter formatter = new XmlFormatter();
    BusinessObjectOne boo = new BusinessObjectOne(...);
    
    // With visitor like double dispatch
    String xml = boo.Format(formatter);
    
    // Without 
    String xml = formatter.FormatBusinessObjectOne(boo);
    
    // With overloading
    String xml = formatter.Format(boo);
