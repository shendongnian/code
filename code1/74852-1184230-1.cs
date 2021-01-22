    <exceptionPolicies>
      <add name="ExPol1">
        <exceptionTypes>
          <add type="System.ArgumentNullException, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
            postHandlingAction="None" name="ArgumentNullException">
            <exceptionHandlers>
              <add logCategory="General" eventId="100" severity="Error" title="Enterprise Library Exception Handling"
                formatterType="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.TextExceptionFormatter, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                priority="0" useDefaultLogger="false" type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging.LoggingExceptionHandler, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Logging, Version=4.1.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
                name="Logging Handler" />
            </exceptionHandlers>
          </add>
        </exceptionTypes>
      </add>
    </exceptionPolicies>
