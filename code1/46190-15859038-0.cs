    This error occurs due to mismatch of Service name in .SVC file. Probably you might have changed the name of the service class that is implementing the interface.The Solution is to open .SVC file and exactly match the Service attribute and CodeBehind Attribute. So your .SVC file should be like
    <%@ ServiceHost Language="Language you are using" Debug="bool value to enable debugging" Service="Service class name that is implementing your Service interface" Codebehind="~/Appcode/Class implementing interface.cs"%>. for eg.
    
    <%@ ServiceHost Language="C#" Debug="true" Service="Product.Service" CodeBehind=~/AppCode/Product.Service.cs"%>
    
    This example is for .svc file that is using C# language, with debugging enabled, Service class implementing interface and this class is within app folder with name Service.cs and Product is namespace for Service class.
    
    Also Please make respective change in service config file.
    <system.serviceModel>
    <services>
    <service name="Product.Service" behaviorConfiguration="ServiceBehavior">
    <endpoint address="" binding="wsHttpBinding" contract="Product.Iservice">
    </endpoint>
    <endpoint address="mex" binding="mexHttpBinding" contract="IMetadataExchange"/>
    </service>
    </services>
    <behaviors>
    <behavior name="ServiceBehavior">
    <serviceMetaData httpGetEnabled="true"/>
    <serviceDebug includeExceptionDetailInFaults="false"/>
    </behavior>
    </behaviors>
    </system.serviceModel>
