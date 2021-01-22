    using Microsoft.Search.Interop;
    using Microsoft.Office.Interop.Outlook;
    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Text;
    using System.Net;
    using System.Security.Principal;
    
    namespace PstIndexingDisabler
    {
        class Program
        {
            static void Main(string[] args)
            {
                Application objApp = null;
                ISearchManager objManager = null;
                ISearchCatalogManager objCatalog = null;
                ISearchCrawlScopeManager objScope = null;
                string strSID = null;
                try
                {
                    Console.WriteLine("Creating search management objects...");
                    objManager = new CSearchManagerClass();
                    objCatalog = objManager.GetCatalog("SystemIndex");
                    objScope = objCatalog.GetCrawlScopeManager();
                    Console.WriteLine("Obtaining currently logged user's SID...");
                    strSID = String.Concat("{", WindowsIdentity.GetCurrent().User.Value.ToString().ToLower(), "}");
                    Console.WriteLine("  The SID is: {0}", strSID);
                    Console.WriteLine("Starting Outlook application...");
                    objApp = new Application();
                    Console.WriteLine("Enumerating PST files...");
                    foreach (Store objStore in objApp.GetNamespace("MAPI").Stores)
                    {
                        Console.WriteLine("Analysing file: {0}...", objStore.FilePath);
                        if (objStore.ExchangeStoreType != OlExchangeStoreType.olNotExchange || objStore.IsCachedExchange != true)
                            Console.WriteLine("  Rejected. This file is not cached exchange store.");
                        else if (Path.GetPathRoot(objStore.FilePath).StartsWith("C", StringComparison.OrdinalIgnoreCase))
                            Console.WriteLine("  Rejected. This file is located on the C: drive.");
                        else if (objStore.IsInstantSearchEnabled != true)
                            Console.WriteLine("  Rejected. Instant search was already disabled for this file.");
                        else
                        {
                            Console.WriteLine("  Accepted. Indexing of this file will be disabled.");
                            Console.WriteLine("    Computing store hash...");
                            string strHash = ComputeHash(objStore.StoreID);
                            Console.WriteLine("      The hash is: {0}.", strHash);
                            string strUrl = String.Format("mapi://{0}/{1}(${2})/", strSID, objStore.DisplayName, strHash);
                            Console.WriteLine("    Disabling indexing...");
                            Console.WriteLine("      The rule url is: {0}.", strUrl);
                            objScope.AddUserScopeRule(strUrl, 0, 1, 0);
                            objScope.SaveAll();
                            Console.WriteLine("    Operation successfull!");
                        }
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("An error occured!");
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Press return to exit.");
                Console.ReadLine();
            }
            private static string ComputeHash(string storeEID)
            {
                int idx = 0;    // Index in buffer
                uint hash = 0;    // The hash
                int lengthStoreEID = storeEID.Length / 2; // Length of store EID -- divide by 2 because 2 text characters here represents 1 byte
                // --- Pass 1: Main block (multiple of dword, i.e. 4 bytes) ---
                int cdw = lengthStoreEID / sizeof(uint);    // cdw = Count Double Words (i.e. number of double words in the buffer)
                for (int i = 0; i < cdw; i++, idx += 8)
                {
                    int dword = int.Parse(storeEID.Substring(idx, 8), System.Globalization.NumberStyles.HexNumber);
                    hash = (hash << 5) + hash + (uint)IPAddress.HostToNetworkOrder(dword);
                }
                // --- Pass 2: Remainder of the block ---
                int cb = lengthStoreEID % sizeof(uint);    // cb = Count Bytes (i.e. number of bytes left in the buffer after pass 1)
                for (int j = 0; j < cb; idx++, j++)
                {
                    hash = (hash << 5) + hash + byte.Parse(storeEID.Substring(idx, 2), System.Globalization.NumberStyles.HexNumber);
                }
                return hash.ToString("x");
            }
            private static string EncodeEID(string EID)
            {
                StringBuilder result = new StringBuilder(EID.Length);
                for (int i = 0; i < EID.Length; i += 2)
                    result.Append((char)(byte.Parse(EID.Substring(i, 2), System.Globalization.NumberStyles.HexNumber) + 0xAC00));
                return result.ToString();
            }
        }
    }
