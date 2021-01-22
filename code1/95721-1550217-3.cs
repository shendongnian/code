    <type type="MyObject" mapTo="MyObject" name="MyObject">
      <typeConfig extensionType="Microsoft.Practices.Unity.Configuration.TypeInjectionElement, Microsoft.Practices.Unity.Configuration"> 
        <constructor> 
          <param name="someInt" parameterType="int"> 
            <value value="12"/>
          </param> 
          <param name="someText" parameterType="string">
            <value value="Hello Unity!"/>
          </param> 
        </constructor> 
        <property name="MyStringProperty" propertyType="string">
          <value value="SomeText"/>
        </property>
      </typeConfig> 
    </type>
