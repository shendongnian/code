    public void hladame_fieldy ()
    {
                    //fieldy
                    string nazov_fieldu;
                    decimal celkovy_pocet_fieldov = selenium.GetXpathCount ("//input[@type='text']");
                    string field = "@type='text'";
                    int b = 1;
                    for (b = 1;b<=celkovy_pocet_fieldov;b++)
                    {
                            nazov_fieldu = selenium.GetAttribute("xpath=//input[" + b + "]@name");
                            Console.WriteLine(nazov_fieldu);
                    }
                    Console.WriteLine ("Celkovy pocet fieldov je = " + celkovy_pocet_fieldov);
            }
