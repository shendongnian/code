    <configuration>
      <component id="smtpClient" type="System.Net.Mail.SmtpClient, System">
        <parameters>
          <Host>127.0.0.1</Host>
          <Port>25</Port>
        </parameters>
      </component>
      <component id="smtpClientWrapper" type="Naespace.SmtpClientWrapper, Assembly">
        <parameters>
          <smtpClient>${smtpClient}</smtpClient>
        </parameters>
      </component>
      <component id="smtpProvider" service="Namespace.IMessageProvider, Assembly" type="Namespace.SmtpEmailProvider, Assembly">
        <parameters>
          <smtpClientWrapper>${smtpClientWrapper}</smtpClientWrapper>
        </parameters>
      </component>
    </configuration>
