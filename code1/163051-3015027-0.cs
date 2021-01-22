    <system.serviceModel>
        <bindings>
          <customBinding>
            <binding name="CustomBindingWithCustomMessageEncoder">
              <CustomMessageEncoder />
            </binding>
          </customBinding>
        </bindings>
        <extensions>
          <bindingElementExtensions>
            <add name="CustomMessageEncoder" type="Full.NameSpace.To.CustomMessageEncoderBindingElementExtension, Assembly.CustomMessageEncoder.Lives.In, Version=1.0.0.0, Culture=neutral, PublicKeyToken=xyz" />
          </bindingElementExtensions>
        </extensions>
      </system.serviceModel>
