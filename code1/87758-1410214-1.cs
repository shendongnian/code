    using System;
    
    using System.Collections.Generic;
    
    using System.Text;
    
    using CAPICOM;
    
    using System.Collections;
    
    using System.Runtime.InteropServices;
    
    
    namespace CertTool
    
    {
    
        class Program
        {
            const uint CERT_SYSTEM_STORE_LOCAL_MACHINE = 0x20000;
            const int CAPICOM_PROPID_FRIENDLY_NAME = 11;
            const int CAPICOM_ENCODE_BINARY = 1;
    
            static private String _currStoreName = "My";
            static private String _FriendlyName = "Not Set";
            static private String _CertPath = "C:\\test.cer";
            static StoreClass _oCurrStore;
            static ExtendedPropertyClass _friendlyProp;
            static CertificateClass _certificate;
            static ExtendedProperties _extendedProp;
    
            static void Main(string[] args)
            {
                try
                {
                    //Friendly name Argument
                    if (args.Length > 0)
                    {
                        _FriendlyName = args[0];
                    }
                    //Certpath argument
                    if (args.Length > 1) 
                    {
                        _CertPath = args[1];
                    }
                    //Set and open the Store
                    _oCurrStore = new StoreClass();
                    _oCurrStore.Open(
                        CAPICOM_STORE_LOCATION.CAPICOM_LOCAL_MACHINE_STORE,
                        _currStoreName,
                        CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_EXISTING_ONLY |
                        CAPICOM_STORE_OPEN_MODE.CAPICOM_STORE_OPEN_MAXIMUM_ALLOWED);
                    //Call the import certificate function
                    importCert();
                }
                catch(Exception ex){
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(args[0]);
                }
            }
            //Function import the certificate to the machine store and sets the friendly name
            static bool importCert()
            {
                try
                {
                    //Create Certificate Object
                    _certificate = new CertificateClass();
                    //Load the certificate into the obejct from file
                    _certificate.Load(_CertPath, "", CAPICOM_KEY_STORAGE_FLAG.CAPICOM_KEY_STORAGE_EXPORTABLE, CAPICOM_KEY_LOCATION.CAPICOM_LOCAL_MACHINE_KEY);
                    //Create extended property Class for friendly name
                    _friendlyProp = new ExtendedPropertyClass();
                    _friendlyProp.PropID =  CAPICOM_PROPID.CAPICOM_PROPID_FRIENDLY_NAME;
                    _friendlyProp.set_Value(CAPICOM_ENCODING_TYPE.CAPICOM_ENCODE_BINARY, _FriendlyName);
    
                    //Add extendedProp on cert object
                    _extendedProp = _certificate.ExtendedProperties();
                    //Set extendded prop to friendly name object
                    _extendedProp.Add(_friendlyProp);
                    _oCurrStore.Add(_certificate);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(_CertPath);
                    return true;
                }
            }
        }
    }
