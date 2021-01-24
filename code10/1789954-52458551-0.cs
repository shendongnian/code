    public static class Program
    {
        public static void Main()
        {
            var rolls = LoadRolls();
            // Once the contents of the file are in memory you can also manipulate them         
            Roll firstRoll = rolls.SingleOrDefault(x => x.Rollnumber == 1);
            if (firstRoll != null)
            {
                firstRoll.StudentName = "Jerry";
            }
            // Let's just add a few records. 
            rolls.AddRange(
                new List<Roll>{
                    new Roll { Rollnumber = 1, StudentName = "Elaine" },
                    new Roll { Rollnumber = 2, StudentName = "George" }
                });
           
            string json = JsonConvert.SerializeObject(rolls, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Rolls.txt", json);
            Console.Read();
        }
        private static List<Roll> LoadRolls()
        {
            List<Roll> rolls = JsonConvert.DeserializeObject<List<Roll>>(File.ReadAllText("Rolls.txt"));
            return rolls ?? new List<Roll>();
        }
    }
    public class Roll
    {
        public int Rollnumber { get; set; }
        public string StudentName { get; set; }
    }
