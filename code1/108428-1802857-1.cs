        using System;
        using ADOX;
        public class CreateDB
        {
            public static void Main( string [] args )
            {
                ADOX.CatalogClass cat = new ADOX.CatalogClass();
                string create =
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data
                Source=C:\BlankAccessDB\MyAccessDBCreatedFromCsharp.mdb;" +
                "Jet OLEDB:Engine Type=5";
                cat.Create(create);
                cat = null;
            }
        }
