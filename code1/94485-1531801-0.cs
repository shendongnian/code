        static void Main(string[] args)
        {
            string format = "#";
            DateTime myDate = DateTime.Now;
            if (myDate.ValidateFormat(format))
                Console.WriteLine(myDate.ToString(format));
            else
                Console.WriteLine("Bad format");
            Console.ReadLine();
        }
        static bool ValidateFormat(this DateTime date, string format)
        {
            try
            {
                string dummy = date.ToString(format);
                return true;
            }
            catch
            {
                return false;
            }
        }
