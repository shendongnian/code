  <webServices>
    <jsonSerialization>
    <profileService>
    <authenticationService>
    <roleService>
...
Somewhere bellow in the config file.
They are all from Microsoft the first three being from EnterpriseLibrary.
The rest are used for AJAX support in ASP.NET.
If you're wondering what this means:
    System.Web.Configuration.ScriptingProfileServiceSection, System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
It's a fully qualified type name:
Class name:
    System.Web.Configuration.ScriptingProfileServiceSection
Assembly name:
    System.Web.Extensions
Assembly version:
    Version=3.5.0.0
Culture of the assembly (language):
    Culture=neutral
And public key token:
    PublicKeyToken=31BF3856AD364E35
The public key token is part of the public key which uniquely identifies the assembly (dll).
