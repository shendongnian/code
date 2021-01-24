        <bindings>
          <wsHttpBinding>
            <binding name="wsbd">
              <security mode="Message">
                <message clientCredentialType="UserName"/>
              </security>
            </binding>
          </wsHttpBinding>
    </bindings>
        <behaviors>
          <serviceBehaviors>
            <behavior name="svbhv">
              <serviceAuthorization principalPermissionMode="Custom">
                <authorizationPolicies>
                  <add policyType="Server7.CustAuthorPolicy,Server7"/>
                </authorizationPolicies>
              </serviceAuthorization>
              <serviceCredentials>
                <userNameAuthentication userNamePasswordValidationMode="Custom" customUserNamePasswordValidatorType="Server7.MyCustUserNamePassValidator,Server7"/>
              </serviceCredentials>
              <serviceDebug includeExceptionDetailInFaults="true"/>
            </behavior>
          </serviceBehaviors>
        </behaviors>
