    using System;
    
    class Program
    {
        static void Main()
        {
            string dummyString = "<b>Dummy Alerts: </b>3/3Alerts have been addressed&#10; Question Alert: Have you had problems or are your volumes lower than normal?  " +
                "Yes Alert is closed on 01/09/2018 at 01:08 PM&#10; Question Alert: Have you been drinking more fluid? " +
                " Yes Alert is closed on 10/09/2019 at 01:08 PM&#10;&#10;Ram support visit performed 10/9/17,  Weight 90.2kg (dry). " +
                "TW achieved. No peripheral edema. BP within routine range per patient history. Urine output 1050ml. No PO fluid restriction at this time. " +
                "Patient did forget to bring in flow sheets.  Monitor UF trend with flow sheet review in one week. Michelle Mayhew Smith, RN.";
                
            var splitted = dummyString.Split(new string[]{"&#10;"}, StringSplitOptions.None);
            
            Console.WriteLine(splitted[splitted.Length-1]);
        }
    }
