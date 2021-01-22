      <?xml version="1.0" encoding="utf-8" ?>
      <configuration>
        <configSections>
          <sectionGroup name="applicationSettings" type="System.Configuration.ApplicationSettingsGroup, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" >
            <section name="SharedConfig.Client.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
            <!-- Begin copy from library app.config -->
            <section name="SharedConfig.Library.Properties.Settings" type="System.Configuration.ClientSettingsSection, System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
            <!-- End copy from library app.config -->
          </sectionGroup>
        </configSections>
        <applicationSettings>
          <SharedConfig.Client.Properties.Settings>
            <setting name="Bar" serializeAs="String">
              <value>BarFromClient</value>
            </setting>
          </SharedConfig.Client.Properties.Settings>
          <!-- Begin copy from library app.config -->
          <SharedConfig.Library.Properties.Settings>
            <setting name="Bar" serializeAs="String">
              <value>BarFromLibrary</value>
            </setting>
          </SharedConfig.Library.Properties.Settings>
          <!-- End copy from library app.config -->
        </applicationSettings>
      </configuration>
