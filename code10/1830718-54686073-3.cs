    <system.web>
      <siteMap defaultProvider="MenuSiteMapProvider" enabled="true">
          <providers>
              <add name="MenuSiteMapProvider" description="Default Site Map Provider" type="System.Web.XmlSiteMapProvider" siteMapFile="Menu.sitemap" securityTrimmingEnabled="true" />
              <add name="MemberSiteMapProvider" description="Member Site Map Provider" type="System.Web.XmlSiteMapProvider" siteMapFile="Member.sitemap" securityTrimmingEnabled="true" />
          </providers>
      </siteMap>
    </system.web>
