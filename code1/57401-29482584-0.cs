    using System;
    using System.Linq;
    using System.IdentityModel.Tokens;
    using System.Security.Cryptography.X509Certificates;
    
    class Program
    {
    	static void Main( string[] args )
    	{
    		var certPath = @"C:\blah\somecert.pfx";
    		var certPassword = "somepassword";
    
    		var orig = new X509Certificate2( certPath, certPassword, X509KeyStorageFlags.Exportable );
    		Console.WriteLine( "Orig   : RawData.Length = {0}, HasPrivateKey = {1}", orig.RawData.Length, orig.HasPrivateKey );
    		
    		var certBytes = orig.Export( X509ContentType.Cert );
    		var certA = new X509Certificate2( certBytes );
    		Console.WriteLine( "cert A : RawData.Length = {0}, HasPrivateKey = {1}, certBytes.Length = {2}", certA.RawData.Length, certA.HasPrivateKey, certBytes.Length );
    
            // NOTE that this the only place the byte count differs from the others
    		certBytes = orig.Export( X509ContentType.Pfx );
    		var certB = new X509Certificate2( certBytes );
    		Console.WriteLine( "cert B : RawData.Length = {0}, HasPrivateKey = {1}, certBytes.Length = {2}", certB.RawData.Length, certB.HasPrivateKey, certBytes.Length );
    
    		var keyIdentifier = ( new X509SecurityToken( orig ) ).CreateKeyIdentifierClause<X509RawDataKeyIdentifierClause>();
    		certBytes = keyIdentifier.GetX509RawData();
    		var certC = new X509Certificate2( certBytes );
    		Console.WriteLine( "cert C : RawData.Length = {0}, HasPrivateKey = {1}, certBytes.Length = {2}", certC.RawData.Length, certC.HasPrivateKey, certBytes.Length );
    
    		Console.WriteLine( "RawData equals original RawData: {0}", certC.RawData.SequenceEqual( orig.RawData ) );
    
    		Console.ReadLine();
    	}
    }
