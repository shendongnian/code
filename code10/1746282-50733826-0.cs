    var dairy = _ippDetailServices.GetDairyHeaderInfoByEmail(id).Where(p => 
    p.ATTRIBUTE15 == id).Select(jk=> new { jk.HEADER_ID_PK, 
    jk.VENDOR_ID, 
    jk.VENDOR_SITE_ID, 
    jk.VENDOR_NAME, 
    jk.ADDRESS_LINE1, 
    jk.ATTRIBUTE15 
    }).GroupBy(p => new { p.HEADER_ID_PK, 
    p.VENDOR_ID, p.VENDOR_SITE_ID, 
    p.VENDOR_NAME, p.ADDRESS_LINE1, 
    p.ATTRIBUTE15 }).Select(p => new { 
    header_id_pk = p.Key, invoice_id_pk = 
    _ippDetailServices.GetDairyHeaderInfoByEmail(id).Where(k => k.HEADER_ID_PK == 
    p.Key.HEADER_ID_PK).Select(c => new { c.APP_INVOICES_ID_PK, 
    c.INVOICE_TYPES, 
    c.IS_HOURLY }).ToList() }).ToList(); 
