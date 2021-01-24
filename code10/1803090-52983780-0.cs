    class Program
    {
        static void Main(string[] args)
        {
            var zohozoho_atliview92 = "{\"Itinerary\":[ {\"Client_Email\":\"garymc\", \"Client_Name\":\"Gary\", \"NT_Number\":\"NT-1237\",\"Number_of_Nights\":7, \"ID\":\"24297940\", \"Itinerary_Name\":\"Icelandnights\", \"Tour_Template_Name\":\"Iceland FireDrive\", \"Departure_Date\":\"2018-07-04\"}]}";
            JObject jObject = JObject.Parse(zohozoho_atliview92);
            Console.WriteLine(jObject);
            Console.ReadLine();
        }
    }
