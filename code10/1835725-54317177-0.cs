    public class MessageCompressionBehavior : IDispatchMessageInspector, IServiceBehavior, IClientMessageInspector
    {
       
    }
    public class CompressionBehaviorExtensionElement :BehaviorExtensionElement
    {
    }
     <extensions> 
                <behaviorExtensions> 
                    <add name="compression" type="yournamespace.CompressionBehaviorExtensionElement, yourassembly, Version=...., Culture=neutral, PublicKeyToken=......"/> 
                </behaviorExtensions> 
     </extensions>
    <behaviors>
       <serviceBehavior>
             <compression />
       </serviceBehavior>
    </behaviors>
