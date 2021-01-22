    using System;
    using System.IO;
    
    namespace AddressParser
    {
      class Program
      {
        public class TownInfo
        {
          public int TownID { get; set; }
          public string TownIDAsString { get; set; }
          public string Town { get; set; }
        }
    
        public class Citizen
        {
          public TownInfo Town { get; set; }
          public string Street { get; set; }
          public string FirstName { get; set; }
          public string Surname { get; set; }
          public string Building { get; set; }
          public string Flat { get; set; }
          public string CardID { get; set; }
        }
    
        static void Main(string[] args)
        {
          string dataFile = @"d:\testdata\TextFile1.txt";
    
          ParseAddressFileToDatabase(dataFile);
        }
    
        static void ParseAddressFileToDatabase(string dataFile)
        {
          using(StreamReader sr = new StreamReader(dataFile))
          {
            string line;
            int lineCount = 0;
    
            string currentStreet = null;
            TownInfo townInfo = null;
    
            while((line = sr.ReadLine()) != null)
            {
              if(lineCount == 0)
              {
                townInfo = ParseTown(line);
              }
    
              if(line.Trim() == String.Empty)
                continue;
    
              while(line != null && line.StartsWith("  "))
              {
                Citizen citizen = ParseCitizen(line, townInfo, currentStreet);
    
                //
                // Insert record into DB here
                //
    
                line = sr.ReadLine();
              }
    
              currentStreet = line;
              lineCount++;
            }
          }
        }
    
        private static TownInfo ParseTown(string line)
        {
          string[] town = line.Split('-');
          return new TownInfo()
          {
            TownID = Int32.Parse(town[0].Trim()),
            TownIDAsString = town[0].Trim(),
            Town = town[1].Replace("(Citizens)","").Trim()
          };
        }
    
        private  static Citizen ParseCitizen(string line, TownInfo townInfo, string currentStreet)
        {
          string[] name = line.Substring(2, 23).Trim().Split(' ');
    
          string firstName = name[0];
          string surname = name[name.Length - 1];
          
          // Assumes fixed positions for some fields
          string buildingOrFlat = line.Substring(24, 22).Trim();
          string cardID = line.Substring(46).Trim();
    
          // Split building or flat
          string[] flat = buildingOrFlat.Split(',');
    
          return new Citizen()
          {
            Town = townInfo,
            Street = currentStreet,
            FirstName = firstName,
            Surname = surname,
            Building = flat.Length == 0 ? buildingOrFlat : flat[0],
            Flat = flat.Length == 2 ? flat[1].Trim() : "",
            CardID = cardID
          };
        }
      }
    }
