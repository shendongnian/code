      </authentication>
        <membership>
          <providers>
            <clear />
            <add name="AspNetSqlMembershipProvider" type="System.Web.Security.SqlMembershipProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" connectionStringName="ConnectionString"
             enablePasswordRetrieval="false"
             enablePasswordReset="true"
              requiresQuestionAndAnswer="false"
              requiresUniqueEmail="true"
               passwordFormat="Hashed"
               maxInvalidPasswordAttempts="10"
               minRequiredPasswordLength="6"
               minRequiredNonalphanumericCharacters="0"
               passwordAttemptWindow="10"
               passwordStrengthRegularExpression=""
               applicationName="/"  />
          </providers>
        </membership>
        <profile>
          <providers>
            <clear />
            <add name="AspNetSqlProfileProvider" type="System.Web.Profile.SqlProfileProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" connectionStringName="ConnectionString" applicationName="/" />
          </providers>
        </profile>
        <roleManager enabled="true">
          <providers>
            <clear />
            <add connectionStringName="ConnectionString"
              applicationName="/" name="AspNetSqlRoleProvider" type="System.Web.Security.SqlRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
            <add applicationName="/" name="AspNetWindowsTokenRoleProvider"
              type="System.Web.Security.WindowsTokenRoleProvider, System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
          </providers>
        </roleManager>
