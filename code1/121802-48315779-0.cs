     <system.serviceModel>
      <services>
       <service name="WcfCustomLibrary.Service1">
        <host>
          <baseAddresses>
            <add baseAddress = "http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary/Service1/" />
          </baseAddresses>
        </host>
       </service>
      </services>
     </system.serviceModel>
    namespace WcfCustomLibrary
    {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
