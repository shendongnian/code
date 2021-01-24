     foreach (Autok item in aLista)
                {
               sW.WriteLine(item.Termekkod +
                            item.Gyarto+ 
                            item.Tipus+ 
                            item.Szin+
                            item.Felszereltsegiszint + 
                            item.Ar+"");
                    sW.Close();
                }
