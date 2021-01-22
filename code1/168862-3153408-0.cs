    <configuration>
      <configSections>
        <section
          name="serviceKnownTypes"
          type="WpfApplication1.ServiceKnownTypesSection, WpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
      </configSections>
      <serviceKnownTypes>
        <declaredServices>
          <serviceContract type="WpfApplication1.IContract, WpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null">
            <knownTypes>
              <knownType type="WpfApplication1.MyData, WpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
            </knownTypes>
          </serviceContract>
        </declaredServices>
      </serviceKnownTypes>
    </configuration>
