    class Program
    {
        // some safe location
        private static var path = "";
        static void Main(string[] args)
        {
            //get the saved tade
            var saveDate = GetLastSavingDate();
            var today = DateTime.Now;
            //var todaysDate = DateTime.Now.Date;
            //var firstOfMonth = new DateTime(todaysDate.Year, todaysDate.Month, 1);
            //var monthEnd = firstOfMonth.AddMonths(1).AddDays(-1);
            var fileGenerated = false;
            // check if the difference in months exceeded 1 - this will be true on every 1st of new month, for example 8 - 7 or even 1 - 12
            if(Math.Abs(today.Month - saveDate.Month) >= 1)
            {
                var filetouploadone = generatefileone("sproc_name");
                var filetouploadtwo = generatefiletwo("sproc_name");
                filegenerated = true;
                // save date
                File.WriteAllText(path, JsonConvert.SerializeObject(today));
            }
        }
        //method to get saved date
        private static DateTime GetLastSavingDate()
        {
            var dt = new DateTime();
            return JsonConvert.DeserializeAnonymousType(File.ReadAllText(path), dt);
        }
    }
