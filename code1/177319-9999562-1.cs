    namespace OFXSharp
    {
        public static class SGMLToXMLFixer
        {
            public static string Fix_SONRS(string original) 
            { .... }
            public static string Fix_STMTTRNRS(string original) 
            { .... }
            
            public static string Fix_CCSTMTTRNRS(string original) 
            { .... }
            private static string Fix_Transactions(string file, string transactionTag, int lastIdx, out int lastIdx_new) 
            { .... }
            private static string Fix_Transactions_Recursive(string file_modified, int lastIdx, out int lastIdx_new) 
            { .... }
        }
    }
