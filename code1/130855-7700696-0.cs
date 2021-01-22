    <?xml version="1.0"?>
    <configuration>
        <system.diagnostics>
            <sources>
                <source name="System.Net.Sockets">
                    <listeners>
                        <add name="Sockets"/>
                    </listeners>
                </source>
            </sources>
            <switches>
                <add name="System.Net.Sockets" value="31"/>
            </switches>
            <sharedListeners>
                <add name="Sockets" type="System.Diagnostics.TextWriterTraceListener" initializeData="c:\socketdump.log"/>
            </sharedListeners>
            <trace autoflush="true"/>
        </system.diagnostics>
    </configuration>
