    <configSections>
      <sectionGroup name="businessObjects">
        <sectionGroup name="crystalReports">
          <section name="printControl" type="System.Configuration.NameValueSectionHandler" />
          <section name="crystalReportViewer" type="System.Configuration.NameValueSectionHandler" />
        </sectionGroup>
      </sectionGroup>
    </configSections>
    <businessObjects>
      <crystalReports>
        <crystalReportViewer>
          <add key="documentView" value="weblayout" />
        </crystalReportViewer>
      </crystalReports>
    </businessObjects>
