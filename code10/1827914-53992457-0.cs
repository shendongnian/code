    <configuration>
      <runtime>
        <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
          <dependentAssembly>
            <assemblyIdentity name="myAssembly"
          publicKeyToken="32ab4ba45e0a69a1"
          culture="en-us" />
            <!-- Assembly versions can be redirected in app,
          publisher policy, or machine configuration files. -->
            <bindingRedirect oldVersion="1.0.0.0-2.0.0.0" newVersion="3.0.0.0" />
          </dependentAssembly>
      <dependentAssembly>
            <assemblyIdentity name="mySecondAssembly"
          publicKeyToken="32ab4ba45e0a69a1"
          culture="en-us" />
                 <bindingRedirect oldVersion="1.0.0.0" newVersion="2.0.0.0" />
          </dependentAssembly>
          <dependentAssembly>
          <assemblyIdentity name="myThirdAssembly"
        publicKeyToken="32ab4ba45e0a69a1"
        culture="en-us" />
            <!-- Publisher policy can be set only in the app
          configuration file. -->
            <publisherPolicy apply="no" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>
