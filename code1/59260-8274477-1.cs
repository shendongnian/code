    <system.serviceModel>
            <serviceHostingEnvironment aspNetCompatibilityEnabled="true" />    
    </system.serviceModel>
    <system.web>
       <caching>
          <outputCacheSettings>
             <outputCacheProfiles>
                <add name=" MyProfile" duration="600" varyByParam="none" sqlDependency="MyTestDatabase:MyTable"/>
             </outputCacheProfiles>
          </outputCacheSettings>
       </caching>
    </system.web>
