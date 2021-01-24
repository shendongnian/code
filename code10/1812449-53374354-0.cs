    XDocument sitemap = XDocument.Load(file.FullName);
						List<XElement> siteElements = (from site in sitemap.Root.Elements(xmlNs + "url")
												where ((string)site.Element(xmlNs + "loc") ?? string.Empty).EndsWith(test.Btw.ToString())
												select site).ToList();
    foreach (var siteElement in siteElements)
    {
        siteElement.ReplaceWith(
	        new XElement(xmlNs + "url",
		        new XElement(xmlNs + "loc",
			        string.Format(CultureInfo.InvariantCulture,
    			    "{0}{1}", test.Taal == EnumTaal.Nl ? NlDomain : FrDomain,
			        test.ToCompanyVat())),
			    new XElement(xmlNs + "lastmod", string.Format("{0}", test.LastMod)),
			    new XElement(xmlNs + "priority", "0.5")
    			)
			);
		}
		sitemap.Save(file.FullName);
