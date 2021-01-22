	using System;
	using System.Security.Cryptography;
	using System.Security.Cryptography.X509Certificates;
	using System.IO;
	public class X509store2
	{
		public static void Main (string[] args)
		{
			//Create new X509 store called teststore from the local certificate store.
			X509Store store = new X509Store ("ROOT", StoreLocation.CurrentUser);
			store.Open (OpenFlags.ReadWrite);
			...
			
			store.Remove (certificate1);
			store.RemoveRange (collection);
			...
			//Close the store.
			store.Close ();
		}    
	}
