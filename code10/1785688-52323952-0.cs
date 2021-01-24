    String str = "Reiter>Reithelme und Sicherheit>Reflexartikel,Pferde>Bandagen und Gamaschen>Glocken und Fesselschutz,Marken>Waldhausen,Reiter>Reithelme und Sicherheit,Pferde>Bandagen und Gamaschen";
    
                    List<String> Splitted = str.Split( ',' ).ToList();
                    foreach ( String Split in Splitted )
                    {
                        if ( Split.Contains("Marken"))
                        {
                            String value = Split.Split( '>' )[1];
                            Console.WriteLine( value );
                            break;
                        }
                    }
