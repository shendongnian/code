    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Collections;
    
    
    namespace SQL
    {
        class TimTest
        {
            public TimTest()
            {
                vars vars = new vars();     // Import vars
                vars.connection.Open();     // Open SQL Connection
    
    
                
    
                string streg = "----------------------------------------------------------------------------------------------------";
    
                Console.WriteLine(streg);
    
                
                //Fornavn(e)
                Console.WriteLine(" Indtast gæstens fornavn(e)");
                string Fornavn = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Efternavn
                Console.WriteLine(" Indtast gæstens efternavn");
                Console.WriteLine(streg);
                string Efternavn = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Adresse
                Console.WriteLine(" Indtast gæstens adresse (Vej og husnummer og Sal/Dør hvis nødvendigt)");
                Console.WriteLine(streg);
                string Adresse = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Postnummer
                Console.WriteLine(" Indtast gæstens postnummer (Vi behøver ikke bynavn) ");
                Console.WriteLine(streg);
                int PostNr = Convert.ToInt32(Console.ReadLine().ToUpper());
                Console.Clear();
    
                //Telefonnummer
                Console.WriteLine(" Indtast gæstens telefon nummer (Dette må gerne være tomt) ");
                Console.WriteLine(streg);
                int TlfNummer = Convert.ToInt32(Console.ReadLine().ToUpper());
                Console.Clear();
    
                //Email
                Console.WriteLine(" Indtast gæstens email adresse (Dette felt må gerne være tomt)");
                Console.WriteLine(streg);
                string Email = Console.ReadLine().ToUpper();
                Console.Clear();
                
    
                //Suite
                Console.WriteLine(" Vil gæsten opgraderes til en suite? ");
                Console.WriteLine(streg);
                string Suite = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Enmands seng
                Console.WriteLine(" Vil gæsten have et enkelt seng på værelset? Skriv JA | Nej ");
                Console.WriteLine(streg);
                string EnkeltSeng = Console.ReadLine().ToUpper();
                Console.Clear();
    
    
                //2x enmands seng
                Console.WriteLine(" Vil gæsten have 2 enkelt senge på værelset? Skriv Ja | Nej ");
                Console.WriteLine(streg);
                string ToSenge = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Dobbeltseng
                Console.WriteLine(" Vil gæsten have en dobbelt seng på værelset? Skriv Ja | Nej ");
                Console.WriteLine(streg);
                string DobbeltSeng = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Altan
                Console.WriteLine(" Vil gæsten have en altan tilknyttet sit værelse? Skriv Ja | Nej ");
                Console.WriteLine(streg);
                string Altan = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Køkken
                Console.WriteLine(" Vil gæsten have eget køkken? Skriv Ja | Nej ");
                Console.WriteLine(streg);
                string Køkken = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Badekar
                Console.WriteLine(" Vil gæsten have badekar på værelset? Skriv Ja | Nej ");
                Console.WriteLine(streg);
                string Badekar = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Jacuzzi 
                Console.WriteLine(" Vil gæsten have spabad på værelset? skriv Ja | Nej ");
                Console.WriteLine(streg);
                string Jacuzzi = Console.ReadLine().ToUpper();
                Console.Clear();
    
                //Opholdets start
                Console.WriteLine(" Hvad dato vil gæsten starte sit ophold? ");
                Console.WriteLine(streg);
                DateTime StartDato = Convert.ToDateTime(Console.ReadLine()); 
                
    
    
    
                List<int> values = new List<int>();
    
                string SQL = "SELECT Pris FROM Vare;";        //SQL Command to execute
                using (SqlCommand command = new SqlCommand(SQL, vars.connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                                values.Add( reader.GetInt16(0));
                        }
                    }
    
                    int prisTotal = 695;
    
                    string[] array = new string[] { "GrundPrisPlaceholder", Suite, EnkeltSeng, ToSenge, DobbeltSeng, Altan, Køkken, Badekar, Jacuzzi };
                    for (int i = 1; i < array.Length; i++)
                    {
                        if (array[i] == "JA")
                            prisTotal += values[i];
                    }
    
                    Console.WriteLine("\n Den totale pris er: " + prisTotal);
    
                    Console.WriteLine("Done.");
                }
                vars.connection.Close();
            }
    
        }
    }
